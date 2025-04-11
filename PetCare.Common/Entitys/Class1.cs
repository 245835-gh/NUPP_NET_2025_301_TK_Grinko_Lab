namespace PetCare.Common.Entitys
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; }
    }
    public class Dog : Animal
    {
        public string Breed { get; set; }
        public string ActivityLevel { get; set; }
    }
    public class Cat : Animal
    {
        public string Furtype { get; set; }
        public bool IsIndependent { get; set; }
    }
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Animal> Pets { get; set; } = new List<Animal>();
    }
}
