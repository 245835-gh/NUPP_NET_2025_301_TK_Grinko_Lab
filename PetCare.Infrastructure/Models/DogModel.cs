namespace PetCare.Infrastructure.Models;

public class DogModel : AnimalModel
{
    public string Breed { get; set; }
    public string ActivityLevel { get; set; }
}