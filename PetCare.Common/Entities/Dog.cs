using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Common.Entities
{
    //Клас собак,що наслідує Animal
    public class Dog : Animal
    {
        public string Breed { get; set; } // Порода собаки
        public string ActivityLevel { get; set; }// Рівень активності (низький, середній, високий)

        //Статичний метод CreateNew
        public static Dog CreateNew()
        {
            var breeds = new[] { "Лабрадор", "Овчарка", "Бульдог", "Хаскі" };
            var activities = new[] { "Низький", "Середній", "Високий" };
            var names = new[] { "Рекс", "Барс", "Дружок", "Мухтар", "Сніжок" };

            var rand = new Random();

            return new Dog
            {
                Id = Guid.NewGuid(),
                Name = names[rand.Next(names.Length)],
                Age = rand.Next(1, 15),
                Species = "Собака",
                Breed = breeds[rand.Next(breeds.Length)],
                ActivityLevel = activities[rand.Next(activities.Length)]
            };
        }

        //Подія
        public event BarkHandler OnBark;

        //Конструктор
        public Dog(string name, int age, string breed, string activityLevel) : base(name, age, "Собака")
        {
            Breed = breed;
            ActivityLevel = activityLevel;
        }

        //Метод для гавкання
        public void Bark()
        {
            OnBark?.Invoke($"{Name} гавкає.Гав-Гав!");
        }

        //Перевизначений метод
        public override string GetInfo()
        {
            return base.GetInfo() + $"Порода:{Breed}, рівень активності:{ActivityLevel}.";
        }
    }
}
