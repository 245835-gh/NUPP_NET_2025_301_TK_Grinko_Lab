using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Common.Services
{
    public class CrudServiseAsync<T> : ICrudServiseAsync<T> where T : class
    {
        private readonly ConcurentDictionary<Guid, T> _storage = new();
        private readonly Func<T,Guid> _getId;
        public CrudServiceAsync()
        {
            var prop = typeof(T).GetProperty("Id");
            if ( prop == null || prop.PropertyType != typeof(Guid))
            {
                throw new InvalidOperationException("Клас повинен мати властивість ID типу Guid");
                _getId = (T obj) => (Guid)prop.GetValue(obj);
            }
        }
    }
}
