using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace PetCare.Common.Services
{
    public class CrudService<T> : ICrudService<T> where T : class
    {
        private readonly Dictionary<Guid, T> _storage = new();
        private Guid GetId(T element)
        {
            var prop = typeof(T).GetProperty("Id");
            return (Guid)prop.GetValue(element);
        }
        public void Create(T element)
        {
            var id = GetId(element);
            _storage[id] = element;

        }
        public T Read(Guid id) => _storage.TryGetValue(id, out var el) ? el : null;

        public IEnumerable<T> ReadAll() => _storage.Values;

        public void Update(T element)
        {
            var id = GetId(element);
            _storage[id] = element;
        }
        public void Remove(T element)
        {
            var id = GetId(element);
            _storage.Remove(id);
        }
        public void Save(string filePath)
        {
            var json = JsonSerializer.Serialize(_storage.Values);
            File.WriteAllText(filePath, json);
        }
        public void Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<T>>(json);
            _storage.Clear();
            foreach (var item in list)
            {
                _storage[GetId(item)] = item;
            }
        }
    }
}
