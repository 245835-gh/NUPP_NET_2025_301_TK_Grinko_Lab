using Microsoft.EntityFrameworkCore;
using PetCare.Infrastructure.Models;

namespace PetCare.Infrastructure;

public class PetCareContext : DbContext
{
    public DbSet<OwnerModel> Owner { get; set; }
    public DbSet<AnimalModel> Animal { get; set; }
    public DbSet<DogModel> Dog { get; set; }

    public PetCareContext(DbContextOptions<PetCareContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AnimalModel>()
            .ToTable("Animal");
        modelBuilder.Entity<DogModel>()
            .ToTable("Dog")
            .HasBaseType<AnimalModel>();

        modelBuilder.Entity<OwnerModel>()
            .HasMany(o => o.Pets)
            .WithOne(a => a.Owner)
            .HasForeignKey(a => a.OwnerId);
    }

}
