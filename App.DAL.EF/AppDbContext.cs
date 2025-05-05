using App.Domain;
using App.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF;

public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid, IdentityUserClaim<Guid>, AppUserRole,
    IdentityUserLogin<Guid>, IdentityRoleClaim<Guid>, IdentityUserToken<Guid>
>
{
    public DbSet<Brand> Brands { get; set; } = default!;
    public DbSet<Miniature> Miniatures { get; set; } = default!;
    public DbSet<MiniatureCollection> MiniatureCollections { get; set; } = default!;
    public DbSet<MiniFaction> MiniFactions { get; set; } = default!;
    public DbSet<MiniManufacturer> MiniManufacturers { get; set; } = default!;
    public DbSet<MiniPaintSwatch> MiniPaintSwatches { get; set; } = default!;
    public DbSet<MiniProperties> MiniProperties { get; set; } = default!;
    public DbSet<MiniState> MiniStates { get; set; } = default!;
    public DbSet<Paint> Paints { get; set; } = default!;
    public DbSet<PaintLine> PaintLines { get; set; } = default!;
    public DbSet<PaintType> PaintTypes { get; set; } = default!;
    public DbSet<Person> Persons { get; set; } = default!;
    public DbSet<PersonPaints> PersonPaints { get; set; } = default!;
    
    public DbSet<AppRefreshToken> RefreshTokens { get; set; } = default!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Remove cascade delete
        foreach (var relationship in builder.Model
                     .GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }
        
        // We have custom UserRole - with separate PK and navigation for Role and User
        // Override default Identity EF config
        builder.Entity<AppUserRole>().HasKey(a => a.Id);
        
        builder.Entity<AppUserRole>().HasIndex(a => new { a.UserId, a.RoleId}).IsUnique();

        builder.Entity<AppUserRole>()
            .HasOne(a => a.User)
            .WithMany(a => a.UserRoles)
            .HasForeignKey(a => a.UserId);

        builder.Entity<AppUserRole>()
            .HasOne(a => a.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(a => a.RoleId);

    }
}