using LabPlus.Domain.Common;

namespace LabPlus.Domain.Entities;

// Weak entity: identified by (ReportId, TestName)
public class TestValue : BaseEntity
{
    public Guid ReportId { get; set; }
    public MedicalReport Report { get; set; } = null!;

    public string TestName { get; set; } = null!;
    public decimal Value { get; set; }
    public string? RefRange { get; set; }
    public string? Unit { get; set; }
    public bool IsAbnormal { get; set; }             // derived
    public bool IsConfirmed { get; set; }
}
