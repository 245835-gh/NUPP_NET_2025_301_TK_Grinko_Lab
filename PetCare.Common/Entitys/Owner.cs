using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Common.Entitys
{
    //Клас для власника тварин
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Animal> Pets { get; set; } = new List<Animal>(); //список власника тварин

        //Конструктор
        public Owner(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }

        //Метод додавання тварин
        public void AddPet(Animal pet)
        {
            Pets.Add(pet);
            Console.WriteLine($"{pet.Name} належить {Name}");
        }
    }
}
