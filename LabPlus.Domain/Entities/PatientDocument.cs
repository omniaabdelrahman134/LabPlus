using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class PatientDocument : BaseEntity
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public string DocType { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string? AiAssessment { get; set; }
    public string? BasicGuidance { get; set; }
    public string? ConsultRecommendation { get; set; }
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

    // "shared in" -> Appointment
    public bool IsShared { get; set; }
    public Guid? SharedAppointmentId { get; set; }
    public Appointment? SharedAppointment { get; set; }

    public bool ReportedIncorrect { get; set; }
    public string? ReportReason { get; set; }
    public ReviewStatus ReviewStatus { get; set; } = ReviewStatus.None;
    public Guid? ReviewedByAdminId { get; set; }
    public Admin? ReviewedByAdmin { get; set; }
}
