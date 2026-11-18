using LabPlus.Domain.Common;
using LabPlus.Domain.Enums;

namespace LabPlus.Domain.Entities;

public class Lab : BaseEntity
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = null!;
    public LabType LabType { get; set; }
    public string Address { get; set; } = null!;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public string LicenseNo { get; set; } = null!;
    public string LicenseDocUrl { get; set; } = null!;
    public string? RejectionReason { get; set; }

    public Guid? ApprovedByAdminId { get; set; }     // Admin "approves" Lab
    public Admin? ApprovedByAdmin { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    public ICollection<MedicalReport> MedicalReports { get; set; } = new List<MedicalReport>();
}
