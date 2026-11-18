using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class Payment : BaseEntity
{
    public Guid AppointmentId { get; set; }
    public Appointment Appointment { get; set; } = null!;

    public int AttemptNo { get; set; } = 1;
    public decimal Amount { get; set; }
    public decimal PlatformShare { get; set; }
    public string? GatewayRef { get; set; }
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    public string? RefundReason { get; set; }
    public RefundDecision RefundDecision { get; set; } = RefundDecision.None;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public Guid? DecidedByAdminId { get; set; }      // Admin "decides" refund
    public Admin? DecidedByAdmin { get; set; }
}
