using jahitpintar.Models;

namespace jahitpintar.Services;

public interface IOcrService
{
    Task<OcrResult?> RecognizeFormAsync(Stream imageStream, string fileName);
}