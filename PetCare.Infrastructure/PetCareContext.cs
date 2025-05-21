using Microsoft.EntityFrameworkCore;
using PetCare.Infrastructure.Models;

namespace PetCare.Infrastructure;

public class PetCareContext : DbContext
{
    public DbSet<OwnerModel> Owners { get; set; }
    public DbSet<AnimalModel> Animals { get; set; }
    public DbSet<DogModel> Dogs { get; set; }

    public PetCareContext(DbContextOptions<PetCareContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OwnerModel>()
            .HasMany(o => o.Pets)
            .WithOne(a => a.Owner)
            .HasForeignKey(a => a.OwnerId);

        modelBuilder.Entity<AnimalModel>()
            .ToTable("Animals");

        modelBuilder.Entity<DogModel>()
            .ToTable("Dogs");

        base.OnModelCreating(modelBuilder);
    }
}
