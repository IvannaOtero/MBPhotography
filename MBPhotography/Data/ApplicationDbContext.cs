using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MBPhotography.Models;

namespace MBPhotography.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // DbSets
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<SessionType> SessionTypes { get; set; }
    public DbSet<Package> Packages { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<PhotoPermission> PhotoPermissions { get; set; }
    public DbSet<Availability> Availabilities { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<GalleryCategory> GalleryCategories { get; set; }
    public DbSet<GalleryImage> GalleryImages { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<AppointmentReminder> AppointmentReminders { get; set; }
    public DbSet<BusinessSettings> BusinessSettings { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Customers: require either Email or PhoneNumber
        builder.Entity<Customer>(b =>
        {
            b.HasKey(c => c.Id);
            b.HasCheckConstraint("CK_Customers_EmailOrPhone", "([Email] IS NOT NULL AND [Email] <> '') OR ([PhoneNumber] IS NOT NULL AND [PhoneNumber] <> '')");
        });

        // Appointment status as string
        builder.Entity<Appointment>(b =>
        {
            b.Property(a => a.Status).HasConversion<string>().HasMaxLength(50);
            b.HasOne(a => a.Customer).WithMany(c => c.Appointments).HasForeignKey(a => a.CustomerId).OnDelete(DeleteBehavior.Cascade);
            b.HasOne(a => a.SessionType).WithMany(s => s.Appointments).HasForeignKey(a => a.SessionTypeId).OnDelete(DeleteBehavior.SetNull);
            b.HasOne(a => a.Package).WithMany(p => p.Appointments).HasForeignKey(a => a.PackageId).OnDelete(DeleteBehavior.SetNull);
        });

        builder.Entity<Payment>(b =>
        {
            b.Property(p => p.PaymentStatus).HasConversion<string>().HasMaxLength(50);
            b.HasOne(p => p.Appointment).WithMany(a => a.Payments).HasForeignKey(p => p.AppointmentId).OnDelete(DeleteBehavior.Cascade);
        });

        builder.Entity<GalleryImage>(b =>
        {
            b.HasOne(g => g.Category).WithMany(c => c.Images).HasForeignKey(g => g.CategoryId).OnDelete(DeleteBehavior.SetNull);
        });

        // Auditable defaults
        builder.Model.GetEntityTypes()
            .Where(t => typeof(IAuditable).IsAssignableFrom(t.ClrType))
            .ToList()
            .ForEach(t =>
            {
                var created = t.FindProperty(nameof(IAuditable.CreatedAt));
                if (created != null)
                {
                    created.SetDefaultValueSql("GETUTCDATE()");
                }
            });
    }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.Entity is IAuditable && (e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var auditable = (IAuditable)entry.Entity;
            if (entry.State == EntityState.Added)
            {
                auditable.CreatedAt = DateTime.UtcNow;
            }
            auditable.UpdatedAt = DateTime.UtcNow;
        }
    }
}
