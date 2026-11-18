using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("payments");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Amount).HasPrecision(18, 2);
        builder.Property(x => x.PlatformShare).HasPrecision(18, 2);
        builder.Property(x => x.GatewayRef).HasMaxLength(100);
        builder.Property(x => x.RefundReason).HasMaxLength(500);

        builder.HasOne(x => x.Appointment).WithMany(a => a.Payments)
               .HasForeignKey(x => x.AppointmentId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.DecidedByAdmin).WithMany()
               .HasForeignKey(x => x.DecidedByAdminId).OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new { x.AppointmentId, x.AttemptNo }).IsUnique();
        builder.HasIndex(x => x.GatewayRef);
    }
}
