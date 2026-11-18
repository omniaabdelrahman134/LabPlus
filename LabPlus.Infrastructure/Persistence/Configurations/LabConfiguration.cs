using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class LabConfiguration : IEntityTypeConfiguration<Lab>
{
    public void Configure(EntityTypeBuilder<Lab> builder)
    {
        builder.ToTable("labs");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(300);
        builder.Property(x => x.LicenseNo).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LicenseDocUrl).IsRequired().HasMaxLength(500);
        builder.Property(x => x.RejectionReason).HasMaxLength(500);
        builder.HasIndex(x => x.LicenseNo).IsUnique();

        builder.HasOne(x => x.ApprovedByAdmin).WithMany()
               .HasForeignKey(x => x.ApprovedByAdminId)
               .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<ApplicationUser>().WithOne()
               .HasForeignKey<Lab>(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.UserId).IsUnique();
    }
}
