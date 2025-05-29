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
        var options = new DbContextOptionsBuilder<PetCareContext>()
            .UseSqlite("Data Source=C:\\Users\\Student\\source\\repos\\NUPP_NET_2025_301_TK_Grinko_Lab\\PetCare.Infrastructure\\petcare.db")
            .Options;

        using var context = new PetCareContext(options);
        var dogRepo = new Repository<DogModel>(context);
        var dogService = new CrudDbService<DogModel>(dogRepo, context);
        var OwnerRepo = new Repository<OwnerModel>(context);
        var OwnerService = new CrudDbService<OwnerModel>(OwnerRepo, context);
        var newOwner = new OwnerModel
        {
            Id = 1,
            FullName = "None"
        };
        var newDog = new DogModel
        {
            Name = "Барс",
            Age = 4,
            Breed = "Овчарка",
            ActivityLevel = "Середній",
            OwnerId = 1
        };

        await OwnerService.CreateAsync(newOwner);
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
