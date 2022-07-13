using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoProject.Domain.Entities;
using ToDoProject.Infrastructure.Interfaces;
using ToDoProject.Persistence.Context;

namespace ToDoProject.Infrastructure.Repositories
{
    public class ToDoListRepository : IToDoRepository<ToDoListEntity>
    {
        private readonly ToDoListContext _context;

        public ToDoListRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<long> AddEntityAsync(ToDoListEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            await _context.Set<ToDoListEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> DeleteEntityByIdAsync(long id)
        {
            var entity = await GetEntityByIdAsync(id);
            if (entity is null) return false;

            _context.Set<ToDoListEntity>().Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistEntityByIdAsync(long id)
        {
            return await _context.Set<ToDoListEntity>().AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<ToDoListEntity>> GetAllAsync() => _context.ToDoListEntities.Include(e => e.ItemsEntities);

        public async Task<ToDoListEntity> GetEntityByIdAsync(long id)
        {
            var entity = await _context.Set<ToDoListEntity>()
                .Include(e => e.ItemsEntities)
                .FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public async Task<IEnumerable<ToDoListEntity>> GetEntitiesByUserAsync(string user) 
            => _context.ToDoListEntities.Where(e => e.User == user);

        public async Task<bool> UpdateEntityAsync(ToDoListEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
