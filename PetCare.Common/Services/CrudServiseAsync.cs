using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetCare.Common.Services
{
    public class CrudServiseAsync<T> : ICrudServiseAsync<T> where T : class
    {
        private readonly ConcurentDictionary<Guid, T> _storage = new();
        private readonly Func<T,Guid> _getId;
        public CrudServiseAsync()
        {
            var prop = typeof(T).GetProperty("Id");
            if ( prop == null || prop.PropertyType != typeof(Guid))
            {
                throw new InvalidOperationException("Клас повинен мати властивість ID типу Guid");
                _getId = (T obj) => (Guid)prop.GetValue(obj);
            }
        }

        public async Task<bool> CreateAsync(T element)
        {
            return await Task.Run(() =>
            {
                var id = _getId(element);
                return _storage.TryAdd(id, element);
            });
        }

        public async Task<T> ReadAsync(Guid id)
        {
            return await Task.Run(() =>
            {
                _storage.TryGetValue(id, out var value);
                return value;
            });
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await Task.FromResult(_storage.Values);
        }

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            return await Task.FromResult(_storage.Value.Skip((page - 1) * amount).Take(amount));
        }

        public async Task<bool> RemoveAsync(T element)
        {
            return await Task.Run(() =>
            {
                var id = _getId(element);
                return _storage.TryRemove(id, out _);
            });
        }

        public async Task<bool> SaveAsync(string filePath)
        {
            try
            {
                var json = JsonSerializer.Serialize(_storage.Value);
                await File.WriteAllTextAsync(filePath, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<T> GetEnumerator() => _storage.Values.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

        public Task<bool> UpdateAsync(T element)
        {
            throw new NotImplementedException();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
