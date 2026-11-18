using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class Notification : BaseEntity
{
    public Guid UserId { get; set; }                 // receiver: any role (Identity user)
    public string NotifType { get; set; } = null!;
    public string Subject { get; set; } = null!;
    public string Body { get; set; } = null!;
    public NotificationChannel Channel { get; set; } = NotificationChannel.InApp;
    public NotificationStatus Status { get; set; } = NotificationStatus.Pending;
    public bool IsRead { get; set; }
    public DateTime? SentAt { get; set; }

    public Guid? SentByAdminId { get; set; }         // Admin "announcements"
    public Admin? SentByAdmin { get; set; }
}
