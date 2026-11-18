using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class ChatbotInteraction : BaseEntity
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public string UserQuestion { get; set; } = null!;
    public string BotAnswer { get; set; } = null!;
    public InputType InputType { get; set; } = InputType.Text;
    public bool DisclaimerShown { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool ReportedIncorrect { get; set; }
    public string? ReportReason { get; set; }
    public ReviewStatus ReviewStatus { get; set; } = ReviewStatus.None;
    public Guid? ReviewedByAdminId { get; set; }
    public Admin? ReviewedByAdmin { get; set; }
}
