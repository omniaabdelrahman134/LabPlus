using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class Appointment : BaseEntity
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    // belongs to exactly ONE of Doctor / Lab (see CHECK constraint)
    public AppointmentType AppointmentType { get; set; }
    public Guid? DoctorId { get; set; }
    public Doctor? Doctor { get; set; }
    public Guid? LabId { get; set; }
    public Lab? Lab { get; set; }

    public ConsultationType? ConsultationType { get; set; }
    public DateTime ScheduledAt { get; set; }
    public DateTime? ProposedAt { get; set; }
    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
    public string? RejectReason { get; set; }
    public string? CancelReason { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public bool DisclaimerAccepted { get; set; }
    public SessionStatus SessionStatus { get; set; } = SessionStatus.NotStarted;
    public string? SessionLink { get; set; }
    public string? MedicalNotes { get; set; }
    public string? RecommendedTests { get; set; }
    public int? Rating { get; set; }
    public string? Feedback { get; set; }
    public string? PackageName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<PatientDocument> SharedDocuments { get; set; } = new List<PatientDocument>();
}
