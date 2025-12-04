#region

using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using jahitpintar.Models;

#endregion

namespace jahitpintar.Services;

public class KolosalService(HttpClient httpClient, IConfiguration configuration) : IKolosalService
{
    private readonly string _apiKey = configuration["kolosal_api_key"] ??
                                      throw new InvalidOperationException("Kolosal API Key is missing");

    private readonly string _baseUrl = "https://api.kolosal.ai";

    public async Task<string> ExtractTextFromImageAsync(Stream imageStream, string fileName)
    {
        var content = new MultipartFormDataContent();
        var imageContent = new StreamContent(imageStream);
        imageContent.Headers.ContentType = new MediaTypeHeaderValue(GetContentType(fileName));
        content.Add(imageContent, "image", fileName);

        // Endpoint: /ocr/process-with-ai-extraction
        // Output: Raw text
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/ocr/process-with-ai-extraction");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        request.Content = content;

        using var response = await httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var responseString = await response.Content.ReadAsStringAsync();

        // Try parsing as JSON to find text field
        try
        {
            using var doc = JsonDocument.Parse(responseString);
            if (doc.RootElement.TryGetProperty("text", out var text)) return text.GetString() ?? "";
            if (doc.RootElement.TryGetProperty("extracted_text", out var extText)) return extText.GetString() ?? "";
            return responseString;
        }
        catch
        {
            return responseString;
        }
    }

    public async Task<Customer> ExtractCustomerFromTextAsync(string text)
    {
        // Use /v1/chat/completions
        var prompt = $@"Ekstrak data berikut menjadi JSON dengan field matching this structure:
{{
  ""identity"": {{ ""name"": """", ""address"": """", ""phone_number"": """", ""date_of_birth"": ""YYYY-MM-DD"", ""social_media_platforms"": [] }},
  ""measurements"": {{ 
    ""upper"": {{ ""chest_circumference"": 0, ""waist_circumference"": 0, ""hip_circumference"": 0, ""neck_circumference"": 0, ""shoulder_width"": 0, ""sleeve_length"": 0, ""armhole_circumference"": 0, ""arm_circumference"": 0, ""wrist_circumference"": 0, ""front_width"": 0, ""back_width"": 0, ""shirt_length"": 0, ""hip_height"": 0 }},
    ""lower"": {{ ""waist_circumference"": 0, ""hip_circumference"": 0, ""leg_length"": 0, ""thigh_circumference"": 0 }},
    ""height"": 0,
    ""weight"": 0
  }},
  ""preferences"": {{ ""fitting_style"": """", ""fabric_favorite"": """", ""order_history"": [] }}
}}
For 'social_media_platforms', detect context (e.g. 'WA: 0812' -> ['WhatsApp']).
Only return the JSON. No markdown.
Teks: {text}";

        var body = new
        {
            model = "MiniMax M2",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var response = await SendRequestAsync<JsonElement>(HttpMethod.Post, "/v1/chat/completions", body);

        // Extract content from choices[0].message.content
        if (response.TryGetProperty("choices", out var choices) && choices.GetArrayLength() > 0)
        {
            var content = choices[0].GetProperty("message").GetProperty("content").GetString();
            if (!string.IsNullOrEmpty(content))
            {
                content = content.Replace("```json", "").Replace("```", "").Trim();
                try
                {
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
                    };
                    return JsonSerializer.Deserialize<Customer>(content, options) ?? new Customer();
                }
                catch
                {
                    // Failed to parse JSON
                }
            }
        }

        return new Customer();
    }

    public async Task<string?> ValidateMeasurementsAsync(Measurements measurements)
    {
        // Use /v1/agent/generate
        var info = JsonSerializer.Serialize(measurements);
        var prompt =
            $"Validasi ukuran badan ini untuk penjahit. Jika ada angka yang sangat tidak masuk akal (misal Lingkar Pinggang 200cm), beri peringatan singkat. Jika wajar, jawab 'OK'. Data: {info}";

        var body = new { prompt };

        try
        {
            var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/v1/agent/generate");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
            request.Content = new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json");

            using var response = await httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();

            try
            {
                using var doc = JsonDocument.Parse(content);
                if (doc.RootElement.TryGetProperty("response", out var resp)) return resp.GetString();
                if (doc.RootElement.TryGetProperty("text", out var txt)) return txt.GetString();
            }
            catch
            {
                return content;
            }

            return content;
        }
        catch
        {
            return null;
        }
    }

    private async Task<T> SendRequestAsync<T>(HttpMethod method, string endpoint, object? body = null,
        MultipartFormDataContent? multipartContent = null)
    {
        var request = new HttpRequestMessage(method, $"{_baseUrl}{endpoint}");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        if (multipartContent != null)
        {
            request.Content = multipartContent;
        }
        else if (body != null)
        {
            var json = JsonSerializer.Serialize(body);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
        }

        using var response = await httpClient.SendAsync(request);

        // Log error if failed
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"API Error {response.StatusCode}: {error}");
        }

        var content = await response.Content.ReadAsStringAsync();
        if (typeof(T) == typeof(string)) return (T)(object)content;

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        return JsonSerializer.Deserialize<T>(content, options) ??
               throw new InvalidOperationException("Response was null");
    }

    private string GetContentType(string fileName)
    {
        var ext = Path.GetExtension(fileName).ToLowerInvariant();
        return ext switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".pdf" => "application/pdf",
            ".webp" => "image/webp",
            _ => "application/octet-stream"
        };
    }
}