using System;
using System.Collections.Generic;
namespace PetCare.Common.Entitys
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

    //Делегат для подій
    public delegate void BarkHandler(string message);

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
    // Клас для котів, що наслідує Animal
    public class Cat : Animal
    {
        public string FurType { get; set; } // Тип шерсті (коротка, довга)
        public bool IsIndependent { get; set; } // Чи любить бути сам

        //Конструктор
        public Cat(string name, int age, string furType, bool isIndependent) : base(name, age, "Кішка")
        {
            FurType = furType;
            IsIndependent = isIndependent;
        }

        //Перевизначений метод
        public override string GetInfo()
        {
            return base.GetInfo() + $"Шерсть:{FurType}, незалежність: {(IsIndependent ? "Так" : "Ні")}";
        }
    }

    //Клас для власника тварин
    public class Owner
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public List<Animal> Pets { get; set; } = new List<Animal>(); //список власника тварин

        //Конструктор
        public Owner(string name,string phoneNumber)
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

    //Статичний метод методом розширення
    public static class AnimalExtensions
    {
        //Метод розширення для класу Animal
        public static void MakeSound(this Animal animal)
        {
            Console.WriteLine(animal is Dog ? "Гав" : animal is Cat ? "Мяу" : "Неопознаний звук");
        }
    }
}
