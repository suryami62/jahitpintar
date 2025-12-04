#region

using System.Text.Json.Serialization;

#endregion

namespace jahitpintar.Models;

public class OcrResult
{
    [JsonPropertyName("title")] public string? Title { get; init; }

    [JsonPropertyName("date")] public string? Date { get; init; }

    [JsonPropertyName("content")] public List<OcrContentItem> Content { get; init; } = new();

    [JsonPropertyName("notes")] public string? Notes { get; init; }

    [JsonPropertyName("confidence_score")] public double ConfidenceScore { get; init; }

    [JsonPropertyName("extracted_text")] public string? ExtractedText { get; init; }
}

public class OcrContentItem
{
    [JsonPropertyName("label")] public string? Label { get; set; }

    [JsonPropertyName("value")] public string? Value { get; set; }
}