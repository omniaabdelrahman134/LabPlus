using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("patients");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);
        builder.Property(x => x.FollowUpNote).HasMaxLength(1000);

        builder.HasOne<ApplicationUser>().WithOne()
               .HasForeignKey<Patient>(x => x.UserId)
               .OnDelete(DeleteBehavior.Restrict);
        builder.HasIndex(x => x.UserId).IsUnique();
    }
}
