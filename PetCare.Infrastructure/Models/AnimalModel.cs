namespace PetCare.Infrastructure.Models;

public class AnimalModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public OwnerModel Owner { get; set; }
    public int OwnerId { get; set; }
}
