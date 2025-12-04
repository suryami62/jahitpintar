#region

using System.Net.Http.Headers;
using System.Text.Json;
using jahitpintar.Models;

#endregion

namespace jahitpintar.Services;

public class OcrService(HttpClient httpClient, IConfiguration configuration) : IOcrService
{
    public async Task<OcrResult?> RecognizeFormAsync(Stream imageStream, string fileName)
    {
        var apiKey = configuration["kolosal_api_key"];

        var request = new HttpRequestMessage(HttpMethod.Post, "https://api.kolosal.ai/ocr/form");

        // Add Authorization header if api key is present
        if (!string.IsNullOrEmpty(apiKey))
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var content = new MultipartFormDataContent();

        var schemaJson = GetExtractionSchemaJson();
        content.Add(new StringContent(schemaJson), "custom_schema");

        // Image content
        var imageContent = new StreamContent(imageStream);
        imageContent.Headers.ContentType = new MediaTypeHeaderValue(GetContentType(fileName));
        content.Add(imageContent, "image", fileName);

        // Other fields from snippet
        content.Add(new StringContent("true"), "invoice");
        content.Add(new StringContent("auto"), "language");

        request.Content = content;

        using var response = await httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            throw new HttpRequestException($"OCR API Error: {response.StatusCode} - {errorContent}");
        }

        var responseString = await response.Content.ReadAsStringAsync();

        // Attempt to deserialize to OcrResult
        try
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            return JsonSerializer.Deserialize<OcrResult>(responseString, options);
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"Failed to deserialize OCR response. Response content: {responseString}", ex);
        }
    }

    private string GetExtractionSchemaJson()
    {
        var schema = new
        {
            name = "custom_extraction",
            strict = true,
            schema = new
            {
                type = "object",
                properties = new Dictionary<string, object>
                {
                    ["title"] = new { type = "string", description = "The main title or heading of the document" },
                    ["date"] = new { type = "string", description = "Any date found in the document" },
                    ["content"] = new
                    {
                        type = "array",
                        items = new
                        {
                            type = "object",
                            properties = new Dictionary<string, object>
                            {
                                ["label"] = new { type = "string", description = "Field name or label" },
                                ["value"] = new { type = "string", description = "The corresponding value" }
                            },
                            required = new[] { "label", "value" },
                            additionalProperties = false
                        },
                        description = "Key-value pairs extracted from the document"
                    },
                    ["notes"] = new { type = "string", description = "Any additional notes or comments found" },
                    ["confidence_score"] = new
                        { type = "number", description = "Confidence score of the extraction accuracy (0.0 to 1.0)" },
                    ["extracted_text"] = new
                        { type = "string", description = "Complete extracted text from the document" }
                },
                required = new[] { "title", "content", "confidence_score", "extracted_text" },
                additionalProperties = false
            }
        };

        return JsonSerializer.Serialize(schema);
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