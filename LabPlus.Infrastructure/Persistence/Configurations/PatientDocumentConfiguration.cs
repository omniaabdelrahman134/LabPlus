using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class PatientDocumentConfiguration : IEntityTypeConfiguration<PatientDocument>
{
    public void Configure(EntityTypeBuilder<PatientDocument> builder)
    {
        builder.ToTable("patient_documents");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.DocType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.FileUrl).IsRequired().HasMaxLength(500);
        builder.Property(x => x.AiAssessment).HasColumnType("text");
        builder.Property(x => x.BasicGuidance).HasColumnType("text");
        builder.Property(x => x.ConsultRecommendation).HasMaxLength(1000);
        builder.Property(x => x.ReportReason).HasMaxLength(500);

        builder.HasOne(x => x.Patient).WithMany(p => p.Documents)
               .HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.SharedAppointment).WithMany(a => a.SharedDocuments)
               .HasForeignKey(x => x.SharedAppointmentId).OnDelete(DeleteBehavior.SetNull);
        builder.HasOne(x => x.ReviewedByAdmin).WithMany()
               .HasForeignKey(x => x.ReviewedByAdminId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.PatientId, x.UploadedAt });
    }
}
