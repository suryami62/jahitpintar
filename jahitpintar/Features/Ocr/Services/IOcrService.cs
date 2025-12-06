#region

using jahitpintar.Features.Ocr.Models;

#endregion

namespace jahitpintar.Features.Ocr.Services;

/// <summary>
///     Defines the contract for OCR (Optical Character Recognition) services.
///     Provides functionality to extract text and structured data from images and documents.
/// </summary>
public interface IOcrService
{
    /// <summary>
    ///     Recognizes and extracts text and structured data from an image or document stream.
    /// </summary>
    /// <param name="imageStream">The stream containing the image or document data to process.</param>
    /// <param name="fileName">The name of the file being processed, used to determine content type.</param>
    /// <returns>A task representing the asynchronous operation, containing the OCR result with extracted data and metadata.</returns>
    Task<OcrResult?> RecognizeFormAsync(Stream imageStream, string fileName);
}