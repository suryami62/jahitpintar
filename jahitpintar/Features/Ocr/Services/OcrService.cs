#region

using System.Net.Http.Headers;
using System.Text.Json;
using jahitpintar.Features.Ocr.Models;

#endregion

namespace jahitpintar.Features.Ocr.Services;

/// <summary>
///     Provides OCR (Optical Character Recognition) functionality for extracting text and structured data from images and
///     documents.
///     Integrates with the Kolosal AI API to perform intelligent document processing.
/// </summary>
public class OcrService(HttpClient httpClient, IConfiguration configuration) : IOcrService
{
    /// <summary>
    ///     Recognizes and extracts text and structured data from an image or document stream.
    /// </summary>
    /// <param name="imageStream">The stream containing the image or document data to process.</param>
    /// <param name="fileName">The name of the file being processed, used to determine content type.</param>
    /// <returns>A task representing the asynchronous operation, containing the OCR result with extracted data and metadata.</returns>
    /// <exception cref="HttpRequestException">Thrown when the OCR API request fails.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the OCR response cannot be deserialized.</exception>
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

    /// <summary>
    ///     Gets the JSON schema for custom extraction configuration.
    ///     Defines the structure and fields to extract from documents during OCR processing.
    /// </summary>
    /// <returns>A JSON string containing the extraction schema configuration.</returns>
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

    /// <summary>
    ///     Determines the appropriate MIME content type based on the file extension.
    /// </summary>
    /// <param name="fileName">The name of the file to analyze.</param>
    /// <returns>The corresponding MIME content type string.</returns>
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