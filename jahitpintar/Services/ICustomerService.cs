using jahitpintar.Models;

namespace jahitpintar.Services;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomersAsync(string userId);
    Task<Customer?> GetCustomerByIdAsync(string id);
    Task SaveCustomerAsync(Customer customer, string userId);
    Task DeleteCustomerAsync(string id);
}