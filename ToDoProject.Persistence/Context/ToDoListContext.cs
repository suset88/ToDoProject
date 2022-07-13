using Microsoft.EntityFrameworkCore;
using ToDoProject.Domain.Entities;

namespace ToDoProject.Persistence.Context
{
    public class ToDoListContext : DbContext
    {
        public DbSet<ToDoListEntity> ToDoListEntities { get; set; }
        public DbSet<ToDoListItemEntity> ToDoListItemEntities { get; set; }

        public ToDoListContext(DbContextOptions<ToDoListContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoListEntity>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<ToDoListItemEntity>().Property(p => p.Id).ValueGeneratedOnAdd();
        }
    }
}
