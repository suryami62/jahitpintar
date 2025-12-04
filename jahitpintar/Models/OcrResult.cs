#region

using System.Text.Json.Serialization;

#endregion

namespace jahitpintar.Models;

public class OcrResult
{
    [JsonPropertyName("title")] public string? Title { get; set; }

    [JsonPropertyName("date")] public string? Date { get; set; }

    [JsonPropertyName("content")] public List<OcrContentItem> Content { get; set; } = new();

    [JsonPropertyName("notes")] public string? Notes { get; set; }

    [JsonPropertyName("confidence_score")] public double ConfidenceScore { get; set; }

    [JsonPropertyName("extracted_text")] public string? ExtractedText { get; set; }
}

public class OcrContentItem
{
    [JsonPropertyName("label")] public string? Label { get; set; }

    [JsonPropertyName("value")] public string? Value { get; set; }
}