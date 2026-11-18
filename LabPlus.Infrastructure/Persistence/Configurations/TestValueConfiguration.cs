using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LabPlus.Infrastructure.Persistence.Configurations;

public class TestValueConfiguration : IEntityTypeConfiguration<TestValue>
{
    public void Configure(EntityTypeBuilder<TestValue> builder)
    {
        builder.ToTable("test_values");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.TestName).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Value).HasPrecision(18, 4);
        builder.Property(x => x.RefRange).HasMaxLength(50);
        builder.Property(x => x.Unit).HasMaxLength(30);

        // weak entity: partial key = test_name inside a report
        builder.HasOne(x => x.Report).WithMany(r => r.TestValues)
               .HasForeignKey(x => x.ReportId).OnDelete(DeleteBehavior.Cascade);
        builder.HasIndex(x => new { x.ReportId, x.TestName }).IsUnique();

        builder.HasQueryFilter(x => !x.Report.IsDeleted);
    }
}
