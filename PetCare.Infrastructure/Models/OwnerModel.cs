namespace PetCare.Infrastructure.Models;

public class OwnerModel
{
    public int Id { get; set; }
    public string FullName { get; set; }

    public List<AnimalModel> Pets { get; set; } = new();
}
