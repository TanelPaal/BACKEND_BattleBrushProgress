using App.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF;

public class AppDbContext : IdentityDbContext
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
    public DbSet<User> Users { get; set; } = default!;
    public DbSet<UserPaints> UserPaints { get; set; } = default!;
    
    
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}