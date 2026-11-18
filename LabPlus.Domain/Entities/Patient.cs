using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class Patient : BaseEntity
{
    public Guid UserId { get; set; }                 // email, password, phone, email_verified -> Identity
    public string FullName { get; set; } = null!;
    public DateOnly? DateOfBirth { get; set; }
    public Gender? Gender { get; set; }
    public bool RemindersEnabled { get; set; } = true;
    public PackageStatus PackageStatus { get; set; } = PackageStatus.None;
    public DateOnly? NextTestDueDate { get; set; }
    public DateOnly? FollowUpDate { get; set; }
    public string? FollowUpNote { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<MedicalReport> MedicalReports { get; set; } = new List<MedicalReport>();
    public ICollection<PatientDocument> Documents { get; set; } = new List<PatientDocument>();
    public ICollection<ChatbotInteraction> ChatInteractions { get; set; } = new List<ChatbotInteraction>();
}
