using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("doctors");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Specialty).IsRequired().HasMaxLength(100);
        builder.Property(x => x.LicenseNo).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LicenseDocUrl).IsRequired().HasMaxLength(500);
        builder.Property(x => x.RejectionReason).HasMaxLength(500);
        builder.Property(x => x.ClinicAddress).HasMaxLength(300);
        builder.Property(x => x.ConsultationFee).HasPrecision(18, 2);
        builder.Property(x => x.AvgRating).HasPrecision(3, 2);
        builder.HasIndex(x => x.LicenseNo).IsUnique();
        builder.HasIndex(x => x.Specialty);

        builder.HasOne(x => x.ApprovedByAdmin).WithMany()
               .HasForeignKey(x => x.ApprovedByAdminId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>().WithOne()
               .HasForeignKey<Doctor>(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.UserId).IsUnique();
    }
}
