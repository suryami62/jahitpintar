using jahitpintar.Data;
using jahitpintar.Models;
using Microsoft.EntityFrameworkCore;

namespace jahitpintar.Services;

public class CustomerService(IDbContextFactory<ApplicationDbContext> factory) : ICustomerService
{
    public async Task<List<Customer>> GetCustomersAsync(string userId)
    {
        using var context = await factory.CreateDbContextAsync();
        return await context.Customers
            .Where(c => c.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(string id)
    {
        using var context = await factory.CreateDbContextAsync();
        return await context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveCustomerAsync(Customer customer, string userId)
    {
        using var context = await factory.CreateDbContextAsync();
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

    public async Task DeleteCustomerAsync(string id)
    {
        using var context = await factory.CreateDbContextAsync();
        var customer = await context.Customers.FindAsync(id);
        if (customer != null)
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }
    }
}