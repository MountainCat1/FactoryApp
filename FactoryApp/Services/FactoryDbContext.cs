using FactoryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FactoryApp.Services;

public class FactoryDbContext : DbContext
{
    public FactoryDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder mb)
    {
        
        base.OnModelCreating(mb);
    }

    public DbSet<DirectorModel> Directors { get; set; } = default!;
    public DbSet<WorkshopModel> Workshops { get; set; } = default!;
    public DbSet<RepairmenModel> Repairmen { get; set; } = default!;
}