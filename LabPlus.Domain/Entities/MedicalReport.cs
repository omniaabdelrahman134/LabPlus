using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class MedicalReport : BaseEntity
{
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; } = null!;

    public Guid? LabId { get; set; }                 // set when the lab uploaded the result
    public Lab? Lab { get; set; }

    public string FileUrl { get; set; } = null!;
    public string FileType { get; set; } = null!;
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;
    public ReportStatus Status { get; set; } = ReportStatus.Uploaded;
    public double? OcrConfidence { get; set; }
    public string? AnalysisResult { get; set; }      // jsonb
    public bool IsKidneyRelated { get; set; }        // derived
    public bool HasCriticalValue { get; set; }       // derived
    public bool PatientConfirmed { get; set; }
    public bool IsDeleted { get; set; }

    // "report incorrect" flow
    public bool ReportedIncorrect { get; set; }
    public string? ReportReason { get; set; }
    public ReviewStatus ReviewStatus { get; set; } = ReviewStatus.None;
    public Guid? ReviewedByAdminId { get; set; }
    public Admin? ReviewedByAdmin { get; set; }

    public ICollection<TestValue> TestValues { get; set; } = new List<TestValue>();
}
