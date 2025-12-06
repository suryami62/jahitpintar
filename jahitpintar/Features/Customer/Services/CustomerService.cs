#region

using jahitpintar.Data;
using Microsoft.EntityFrameworkCore;

#endregion

namespace jahitpintar.Features.Customer.Services;

/// <summary>
///     Provides customer management services for the JahitPintar application.
/// </summary>
/// <param name="factory">The database context factory for creating database contexts.</param>
public class CustomerService(IDbContextFactory<ApplicationDbContext> factory) : ICustomerService
{
    /// <summary>
    ///     Retrieves all customers for the specified user.
    /// </summary>
    /// <param name="userId">The unique identifier of the user.</param>
    /// <returns>A list of customers belonging to the user.</returns>
    public async Task<List<Models.Customer>> GetCustomersAsync(string userId)
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Customers
            .Where(c => c.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    /// <summary>
    ///     Retrieves a specific customer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the customer.</param>
    /// <returns>The customer if found; otherwise, null.</returns>
    public async Task<Models.Customer?> GetCustomerByIdAsync(string id)
    {
        await using var context = await factory.CreateDbContextAsync();
        return await context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    /// <summary>
    ///     Saves a customer to the database (creates new or updates existing).
    /// </summary>
    /// <param name="customer">The customer to save.</param>
    /// <param name="userId">The unique identifier of the user who owns this customer.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task SaveCustomerAsync(Models.Customer customer, string userId)
    {
        await using var context = await factory.CreateDbContextAsync();
        var existing = await context.Customers
            .AsNoTracking() // Just checking existence and ownership, not attaching yet
            .FirstOrDefaultAsync(c => c.Id == customer.Id);

        if (existing == null)
        {
            customer.UserId = userId;
            context.Customers.Add(customer);
        }
        else
        {
            if (existing.UserId != userId)
                throw new UnauthorizedAccessException("Access denied to this customer record.");

            customer.UserId = userId; // Ensure UserId is set correctly
            context.Customers.Update(customer);
        }

        await context.SaveChangesAsync();
    }

    /// <summary>
    ///     Deletes a customer from the database.
    /// </summary>
    /// <param name="id">The unique identifier of the customer to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task DeleteCustomerAsync(string id)
    {
        await using var context = await factory.CreateDbContextAsync();
        var customer = await context.Customers.FindAsync(id);
        if (customer != null)
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }
    }
}