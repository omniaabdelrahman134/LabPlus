using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class Admin : BaseEntity
{
    public Guid UserId { get; set; }                 // -> ApplicationUser (email / password_hash)
    public string FullName { get; set; } = null!;
    public PermissionLevel PermissionLevel { get; set; } = PermissionLevel.Admin;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
