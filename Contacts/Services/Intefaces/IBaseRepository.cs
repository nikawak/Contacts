using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Services.Intefaces
{
    public interface IBaseRepository<T>
    {
        public Task<T> GetAsync(Guid id);
        public Task<IEnumerable<T>> GetAllAsync();
        public Task CreateAsync(T entity);
        public Task DeleteAsync(T entity);
        public Task UpdateAsync(T entity);
    }
}
