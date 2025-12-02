using jahitpintar.Data;
using jahitpintar.Models;
using Microsoft.EntityFrameworkCore;

namespace jahitpintar.Services;

public class CustomerService(ApplicationDbContext context) : ICustomerService
{
    public async Task<List<Customer>> GetCustomersAsync(string userId)
    {
        return await context.Customers
            .Where(c => c.UserId == userId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(string id)
    {
        return await context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task SaveCustomerAsync(Customer customer, string userId)
    {
        var existing = await context.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == customer.Id);

        if (existing == null)
        {
            customer.UserId = userId;
            context.Customers.Add(customer);
        }
        else
        {
            if (existing.UserId != userId)
            {
                throw new UnauthorizedAccessException("Access denied to this customer record.");
            }

            customer.UserId = userId; // Ensure UserId is set correctly
            context.Customers.Update(customer);
        }

        await context.SaveChangesAsync();
    }

    public async Task DeleteCustomerAsync(string id)
    {
        var customer = await context.Customers.FindAsync(id);
        if (customer != null)
        {
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }
    }
}
