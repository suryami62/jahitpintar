namespace jahitpintar.Features.Customer.Services;

/// <summary>
///     Defines the contract for customer-related operations in the JahitPintar application.
/// </summary>
public interface ICustomerService
{
    /// <summary>
    ///     Retrieves all customers for the specified user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A list of customers belonging to the user.</returns>
    Task<List<Models.Customer>> GetCustomersAsync(string userId);

    /// <summary>
    ///     Retrieves a specific customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer if found; otherwise, null.</returns>
    Task<Models.Customer?> GetCustomerByIdAsync(string id);

    /// <summary>
    ///     Saves a customer to the database (creates new or updates existing).
    /// </summary>
    /// <param name="customer">The customer to save.</param>
    /// <param name="userId">The unique identifier of the user who owns this customer.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task SaveCustomerAsync(Models.Customer customer, string userId);

    /// <summary>
    ///     Deletes a customer from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DeleteCustomerAsync(string id);
}