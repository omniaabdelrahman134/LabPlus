using LabPlus.Domain.Common;

namespace LabPlus.Domain.Entities;

public class Doctor : BaseEntity
{
    public Guid UserId { get; set; }                 // email, password, account_status -> Identity
    public string FullName { get; set; } = null!;
    public string Specialty { get; set; } = null!;
    public string LicenseNo { get; set; } = null!;
    public string LicenseDocUrl { get; set; } = null!;
    public decimal ConsultationFee { get; set; }
    public string? RejectionReason { get; set; }
    public decimal AvgRating { get; set; }
    public string? ClinicAddress { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public Guid? ApprovedByAdminId { get; set; }     // Admin "approves" Doctor
    public Admin? ApprovedByAdmin { get; set; }

    public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
