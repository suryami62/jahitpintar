#region

using jahitpintar.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

#endregion

namespace jahitpintar.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id);

            // Link to User
            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Owned Types mapping (flattens structure into table)
            entity.OwnsOne(e => e.Identity);

            entity.OwnsOne(e => e.Measurements, m =>
            {
                m.OwnsOne(u => u.Upper);
                m.OwnsOne(l => l.Lower);
            });

            entity.OwnsOne(e => e.Preferences);
        });
    }
}