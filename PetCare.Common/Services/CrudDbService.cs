using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PetCare.Infrastructure;

namespace PetCare.Common.Services
{
    public class CrudDbService<T> : ICrudServiseAsync<T> where T : class
{
    private readonly IRepository<T> _repository;
    private readonly PetCareContext _context;

    public CrudDbService(IRepository<T> repository, PetCareContext context)
    {
        _repository = repository;
        _context = context;
        }
        public async Task<bool> CreateAsync(T element)
        {
            await _repository.AddAsync(element);
            return await _context.SaveChangesAsync() > 0;
        }


    public async Task<T> ReadAsync(Guid id)
    {
        // Примітка: адаптувати для int/Guid
        return await _repository.GetByIdAsync((int)(object)id);
    }

    public async Task<IEnumerable<T>> ReadAllAsync() => await _repository.GetAllAsync();

    public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
    {
        return (await _repository.GetAllAsync()).Skip((page - 1) * amount).Take(amount);
    }

    public async Task<bool> UpdateAsync(T element)
    {
        await _repository.Update(element);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> RemoveAsync(T element)
    {
        await _repository.Delete(element);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> SaveAsync(string v) => await _context.SaveChangesAsync() > 0;

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }

}
