using jahitpintar.Models;

namespace jahitpintar.Services;

public interface IKolosalService
{
    Task<string> CreateWorkspaceAsync(string name);
    Task<List<Customer>> GetCustomersAsync(string workspaceId);
    Task SaveCustomersAsync(string workspaceId, List<Customer> customers);
    Task<string> ExtractTextFromImageAsync(Stream imageStream, string fileName);
    Task<Customer> ExtractCustomerFromTextAsync(string text);
    Task<string?> ValidateMeasurementsAsync(Measurements measurements);
}
