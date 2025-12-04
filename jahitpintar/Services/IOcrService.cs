#region

using jahitpintar.Models;

#endregion

namespace jahitpintar.Services;

public interface IOcrService
{
    Task<OcrResult?> RecognizeFormAsync(Stream imageStream, string fileName);
}