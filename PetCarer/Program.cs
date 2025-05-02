using PetCare.Common.Entities;
using PetCare.Common.Services;
using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Threading.Tasks;

/*var dogService = new CrudService<Dog>();
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
}*/

class Program
{
    static async Task Main()
    {
        var dogService = new CrudServiseAsync<Dog>();
        var catService = new CrudServiseAsync<Cat>();
        var dogs = new ConcurrentBag<Dog>();
        var cats = new ConcurrentBag<Cat>();

        Parallel.Invoke(
            () => Parallel.For(0, 1000, i => dogs.Add(Dog.CreateNew())),
            () => Parallel.For(0, 1000, i => cats.Add(Cat.CreateNew())));

        await Task.WhenAll(
            (Task)dogs.Select(d => dogService.CreateAsync(d)),
            (Task)cats.Select(c => catService.CreateAsync(c))
            );
        // LINQ: аналіз
        var dogList = await dogService.ReadAllAsync();
        var catList = await catService.ReadAllAsync();

        var minAgeDog = dogList.Min(d => d.Age);
        var maxAgeDog = dogList.Max(d => d.Age);
        var avgAgeDog = dogList.Average(d => d.Age);

        var minAgeCat = catList.Min(d => d.Age);
        var maxAgeCat = catList.Max(d => d.Age);
        var avgAgeCat = catList.Average(d => d.Age);

        Console.WriteLine($"Собак створено: {dogList.Count()}");
        Console.WriteLine($"Мін. вік: {minAgeDog}");
        Console.WriteLine($"Макс. вік: {maxAgeDog}");
        Console.WriteLine($"Середній вік: {avgAgeDog:F2}");

        Console.WriteLine($"Котів створено: {catList.Count()}");
        Console.WriteLine($"Мін. вік: {minAgeCat}");
        Console.WriteLine($"Макс. вік: {maxAgeCat}");
        Console.WriteLine($"Середній вік: {avgAgeCat:F2}");

        // Збереження в файл
        await dogService.SaveAsync("dogs.json");
        await catService.SaveAsync("cat.json");
        Console.WriteLine("Дані збережені у файлах: dogs.json та cat.json");

    }
}