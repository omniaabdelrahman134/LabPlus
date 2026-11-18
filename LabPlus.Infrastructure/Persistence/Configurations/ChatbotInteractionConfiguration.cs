using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class ChatbotInteractionConfiguration : IEntityTypeConfiguration<ChatbotInteraction>
{
    public void Configure(EntityTypeBuilder<ChatbotInteraction> builder)
    {
        builder.ToTable("chatbot_interactions");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.UserQuestion).IsRequired().HasColumnType("text");
        builder.Property(x => x.BotAnswer).IsRequired().HasColumnType("text");
        builder.Property(x => x.ReportReason).HasMaxLength(500);

        builder.HasOne(x => x.Patient).WithMany(p => p.ChatInteractions)
               .HasForeignKey(x => x.PatientId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.ReviewedByAdmin).WithMany()
               .HasForeignKey(x => x.ReviewedByAdminId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.PatientId, x.CreatedAt });
    }
}
