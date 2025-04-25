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
