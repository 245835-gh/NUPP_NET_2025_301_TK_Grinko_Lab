using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Common.Entities
{
    // Клас для котів, що наслідує Animal
    public class Cat : Animal
    {
        public string FurType { get; set; } // Тип шерсті (коротка, довга)
        public bool IsIndependent { get; set; } // Чи любить бути сам

        //Статичний метод CreateNew
        public static Cat CreateNew()
        {
            var furTypes = new[] { "Коротка", "Довга", "Середня"};
            var names = new[] { "Мурка", "Сніжинка", "Кузя", "Барсік"};

            var rand = new Random();

            return new Cat
            {
                Id = Guid.NewGuid(),
                Name = names[rand.Next(names.Length)],
                Age = rand.Next(1, 20),
                Species = "Кішка",
                FurType = furTypes[rand.Next(furTypes.Length)],
                IsIndependent = rand.Next(0, 2) == 1
            };
        }

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
}
