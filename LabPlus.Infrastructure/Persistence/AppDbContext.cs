using LabPlus.Domain.Entities;
using LabPlus.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LabPlus.Infrastructure.Persistence;

public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Lab> Labs => Set<Lab>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<MedicalReport> MedicalReports => Set<MedicalReport>();
    public DbSet<TestValue> TestValues => Set<TestValue>();
    public DbSet<PatientDocument> PatientDocuments => Set<PatientDocument>();
    public DbSet<ChatbotInteraction> ChatbotInteractions => Set<ChatbotInteraction>();
    public DbSet<Notification> Notifications => Set<Notification>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<ApplicationUser>().ToTable("users");
        builder.Entity<IdentityRole<Guid>>().ToTable("roles");
        builder.Entity<IdentityUserRole<Guid>>().ToTable("user_roles");
        builder.Entity<IdentityUserClaim<Guid>>().ToTable("user_claims");
        builder.Entity<IdentityUserLogin<Guid>>().ToTable("user_logins");
        builder.Entity<IdentityRoleClaim<Guid>>().ToTable("role_claims");
        builder.Entity<IdentityUserToken<Guid>>().ToTable("user_tokens");

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
    // every enum in the project is stored as a string (readable in pgAdmin)
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Enum>().HaveConversion<string>().HaveMaxLength(30);
    }
}
