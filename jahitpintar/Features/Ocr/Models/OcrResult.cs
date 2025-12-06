#region

using System.Text.Json.Serialization;

#endregion

namespace jahitpintar.Features.Ocr.Models;

/// <summary>
///     Represents the result of an OCR (Optical Character Recognition) operation.
///     Contains extracted text content, metadata, and confidence scores from document processing.
/// </summary>
public class OcrResult
{
    /// <summary>
    ///     Gets or sets the main title or heading extracted from the document.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; init; }

    /// <summary>
    ///     Gets or sets any date information found in the document.
    /// </summary>
    [JsonPropertyName("date")]
    public string? Date { get; init; }

    /// <summary>
    ///     Gets or sets the list of key-value pairs extracted from the document.
    /// </summary>
    [JsonPropertyName("content")]
    public List<OcrContentItem> Content { get; init; } = new();

    /// <summary>
    ///     Gets or sets any additional notes or comments found in the document.
    /// </summary>
    [JsonPropertyName("notes")]
    public string? Notes { get; init; }

    /// <summary>
    ///     Gets or sets the confidence score of the extraction accuracy (0.0 to 1.0).
    /// </summary>
    [JsonPropertyName("confidence_score")]
    public double ConfidenceScore { get; init; }

    /// <summary>
    ///     Gets or sets the complete extracted text from the document.
    /// </summary>
    [JsonPropertyName("extracted_text")]
    public string? ExtractedText { get; init; }
}

/// <summary>
///     Represents a single key-value pair extracted from an OCR-processed document.
/// </summary>
public class OcrContentItem
{
    /// <summary>
    ///     Gets or sets the field name or label.
    /// </summary>
    [JsonPropertyName("label")]
    public string? Label { get; set; }

    /// <summary>
    ///     Gets or sets the corresponding value.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}