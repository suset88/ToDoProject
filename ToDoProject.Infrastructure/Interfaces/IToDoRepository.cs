using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProject.Domain.Entities;

namespace ToDoProject.Infrastructure.Interfaces
{
    public interface IToDoRepository<T> where T : BaseEntity
    {
        Task<long> AddEntityAsync(T entity);
        Task<bool> UpdateEntityAsync(T entity);
        Task<bool> DeleteEntityByIdAsync(long id);
        Task<bool> ExistEntityByIdAsync(long id);
        Task<T> GetEntityByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
