using LabPlus.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace LabPlus.Infrastructure.Identity;

// Email, PasswordHash, PhoneNumber, EmailConfirmed (= email_verified) come from IdentityUser
public class ApplicationUser : IdentityUser<Guid>
{
    public AccountStatus AccountStatus { get; set; } = AccountStatus.Active;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
