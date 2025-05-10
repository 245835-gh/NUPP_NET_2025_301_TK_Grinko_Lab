using PetCare.Common.Entities;
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

        //Статичний метод CreateNew
        public static Cat CreateNew()
        {
            var names = new[] { "Олексій", "Марина", "Ігор", "Анна", "Петро" };
            var phones = new[] { "123-456", "555-999", "777-111", "999-888", "321-654" };

            var rand = new Random();

            return new Owner
            {
                Name = names[rand.Next(names.Length)],
                PhoneNumber = phones[rand.Next(phones.Length)],
                Pets = new List<Animal>
                {
                    Dog.CreateNew(),
                    Cat.CreateNew()
                }
            };
        }

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
