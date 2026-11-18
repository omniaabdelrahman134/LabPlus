using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("appointments", t =>
        {
            // exactly ONE of Doctor / Lab
            t.HasCheckConstraint("ck_appointment_target",
                "(doctor_id IS NOT NULL AND lab_id IS NULL) OR (doctor_id IS NULL AND lab_id IS NOT NULL)");
            t.HasCheckConstraint("ck_appointment_rating",
                "rating IS NULL OR (rating BETWEEN 1 AND 5)");
        });
        builder.HasKey(x => x.Id);

        builder.Property(x => x.RejectReason).HasMaxLength(500);
        builder.Property(x => x.CancelReason).HasMaxLength(500);
        builder.Property(x => x.SessionLink).HasMaxLength(500);
        builder.Property(x => x.MedicalNotes).HasMaxLength(4000);
        builder.Property(x => x.RecommendedTests).HasMaxLength(2000);
        builder.Property(x => x.Feedback).HasMaxLength(2000);
        builder.Property(x => x.PackageName).HasMaxLength(100);

        builder.HasOne(x => x.Patient).WithMany(p => p.Appointments)
               .HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Doctor).WithMany(d => d.Appointments)
               .HasForeignKey(x => x.DoctorId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Lab).WithMany(l => l.Appointments)
               .HasForeignKey(x => x.LabId).OnDelete(DeleteBehavior.Restrict);

        // prevents double-booking the same doctor slot
        builder.HasIndex(x => new { x.DoctorId, x.ScheduledAt })
               .IsUnique()
               .HasFilter("doctor_id IS NOT NULL AND status IN ('Pending','Confirmed')");

        builder.HasIndex(x => new { x.PatientId, x.Status });
        builder.HasIndex(x => x.ExpiresAt);
    }
}
