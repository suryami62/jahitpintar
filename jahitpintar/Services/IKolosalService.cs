#region

using jahitpintar.Models;

#endregion

namespace jahitpintar.Services;

public interface IKolosalService
{
    Task<string> ExtractTextFromImageAsync(Stream imageStream, string fileName);
    Task<Customer> ExtractCustomerFromTextAsync(string text);
    Task<string?> ValidateMeasurementsAsync(Measurements measurements);
    Task<string> ChatWithAiAsync(List<ChatMessage> messages);
}