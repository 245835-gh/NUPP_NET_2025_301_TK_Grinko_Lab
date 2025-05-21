using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace PetCare.Infrastructure
{ 
    public class PetCareContextFactory : IDesignTimeDbContextFactory<PetCareContext>
{
    public PetCareContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<PetCareContext>();
        optionsBuilder.UseSqlite("Data Source=petcare.db");
        return new PetCareContext(optionsBuilder.Options);
    }
}   
}
