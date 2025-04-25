using PetCare.Common.Entities;
using PetCare.Common.Services;
using System;

var dogService = new CrudService<Dog>();
var dog = new Dog("Барс",4,"Овчарка","Високий"){
    Id = Guid.NewGuid(),
    Name = "Барс",
    Age = 4,
    Species = "Собака",
    Breed = "Овчарка",
    ActivityLevel = "Високий"
};
dogService.Create(dog);
Console.WriteLine("Збережені тварини:");
foreach (var d in dogService.ReadAll()){
    Console.WriteLine($"{d.Name} ({d.Breed})");
}
// Зберігаємо
dogService.Save("dogs.json");
// Завантажуємо
var loadedService = new CrudService<Dog>();
loadedService.Load("dogs.json");

Console.WriteLine("\nПісля завантаження:");
foreach (var d in loadedService.ReadAll()){
    Console.WriteLine($"{d.Name} ({d.Breed})");
}