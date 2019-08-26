using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        //я хотел бы избежать в данном случае лишней по-моему мнению абстракции в виде репозиториев,
        //но иначе пришлось бы делать контекст публичным, что не есть хорошо
        public IRepository<Category> CategoryRepository => new CategoryRepository(_context);
        public IRepository<ToDoItem> ToDoItemRepository => new ToDoItemRepository(_context);

        public UnitOfWork(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
