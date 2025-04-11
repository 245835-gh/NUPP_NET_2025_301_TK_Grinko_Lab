using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Common.Entitys
{
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
}
