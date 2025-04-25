using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Common.Entities
{
    //Базовий клас для всіх тварин
    public class Animal
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public int Age { get; set; }
        public string Species { get; set; } // Вид тварини (наприклад, собака, кішка)

        //Статичне поле
        public static int AnimalCount;

        //Статичний конструктор
        static Animal()
        {
            AnimalCount = 0;
        }

        //Конструктор
        public Animal(string name, int age, string species)
        {
            Name = name;
            Age = age;
            Species = species;
            AnimalCount++;
        }

        //Метод отримування інформації про тварину
        public virtual string GetInfo()
        {
            return $"{Name} ({Species}),{Age} років.";
        }
    }
}
