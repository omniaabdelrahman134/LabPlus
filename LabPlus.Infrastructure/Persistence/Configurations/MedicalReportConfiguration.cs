using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class MedicalReportConfiguration : IEntityTypeConfiguration<MedicalReport>
{
    public void Configure(EntityTypeBuilder<MedicalReport> builder)
    {
        builder.ToTable("medical_reports");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FileUrl).IsRequired().HasMaxLength(500);
        builder.Property(x => x.FileType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.AnalysisResult).HasColumnType("jsonb");
        builder.Property(x => x.ReportReason).HasMaxLength(500);

        builder.HasOne(x => x.Patient).WithMany(p => p.MedicalReports)
               .HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Lab).WithMany(l => l.MedicalReports)
               .HasForeignKey(x => x.LabId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ReviewedByAdmin).WithMany()
               .HasForeignKey(x => x.ReviewedByAdminId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.PatientId, x.UploadDate });
        builder.HasQueryFilter(x => !x.IsDeleted);   // soft delete
    }
}
