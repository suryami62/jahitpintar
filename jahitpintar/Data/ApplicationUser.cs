using Microsoft.AspNetCore.Identity;

namespace jahitpintar.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string? WorkspaceId { get; set; }
}
