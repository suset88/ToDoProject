using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoProject.Domain.Entities;
using ToDoProject.Infrastructure.Interfaces;
using ToDoProject.Persistence.Context;

namespace ToDoProject.Infrastructure.Repositories
{
    public class ToDoListItemRepository : IToDoRepository<ToDoListItemEntity>
    {
        private readonly ToDoListContext _context;

        public ToDoListItemRepository(ToDoListContext context)
        {
            _context = context;
        }

        public async Task<long> AddEntityAsync(ToDoListItemEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            await _context.Set<ToDoListItemEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<bool> DeleteEntityByIdAsync(long id)
        {
            var entity = await GetEntityByIdAsync(id);
            if (entity is null) return false;

            _context.Set<ToDoListItemEntity>().Remove(entity);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ExistEntityByIdAsync(long id)
        {
            return await _context.Set<ToDoListItemEntity>().AnyAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<ToDoListItemEntity>> GetAllAsync() => _context.ToDoListItemEntities;

        public async Task<ToDoListItemEntity> GetEntityByIdAsync(long id)
        {
            var entity = await _context.Set<ToDoListItemEntity>()
                .FirstOrDefaultAsync(e => e.Id == id);

            return entity;
        }

        public async Task<bool> UpdateEntityAsync(ToDoListItemEntity entity)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));

            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
