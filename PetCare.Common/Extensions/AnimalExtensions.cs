using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetCare.Common.Entities;

namespace PetCare.Common.Extensions
{
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
