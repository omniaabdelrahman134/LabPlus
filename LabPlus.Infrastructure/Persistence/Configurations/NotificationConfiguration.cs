using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("notifications");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.NotifType).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Subject).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Body).IsRequired().HasColumnType("text");

        // receiver can be any role -> one FK to the Identity user
        builder.HasOne<ApplicationUser>().WithMany()
               .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(x => x.SentByAdmin).WithMany()
               .HasForeignKey(x => x.SentByAdminId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.UserId, x.IsRead });
    }
}
