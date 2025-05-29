using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PetCare.Common.Services;
using PetCare.Infrastructure;
using PetCare.Infrastructure.Models;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Створюємо параметри для SQLite
        var options = new DbContextOptionsBuilder<PetCareContext>()
            .UseSqlite("Data Source=petcare.db")
            .Options;

        // 2. Створюємо контекст і репозиторій
        using var context = new PetCareContext(options);
        var dogRepo = new Repository<DogModel>(context);
        var dogService = new CrudDbService<DogModel>(dogRepo, context);

        // 3. Створюємо нового собаку
        var newDog = new DogModel
        {
            Name = "Барс",
            Age = 4,
            Breed = "Овчарка",
            ActivityLevel = "Середній"
        };

        await dogService.CreateAsync(newDog);

        // 4. Зчитуємо всі дані з БД
        var dogs = await dogService.ReadAllAsync();
        Console.WriteLine("Собаки в базі даних:");
        foreach (var dog in dogs)
        {
            Console.WriteLine($"{dog.Name} ({dog.Breed}), вік: {dog.Age}, активність: {dog.ActivityLevel}");
        }

        Console.WriteLine("Готово!");
    }
}
