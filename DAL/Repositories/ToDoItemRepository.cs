using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    class ToDoItemRepository : IRepository<ToDoItem>
    {
        private readonly AppDbContext _context;

        public ToDoItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task Create(ToDoItem item)
        {
            return _context.Tasks.AddAsync(item);
        }

        public void Delete(ToDoItem item)
        {
            _context.Tasks.Remove(item);
        }

        public Task<ToDoItem> Get(int id)
        {
            return _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<ToDoItem> GetItemsFromCategory(int categoryId)
        {
            return _context.Tasks.Where(x => x.CategoryId == categoryId);
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            return _context.Tasks;
        }

        public async Task Update(ToDoItem newItem)
        {
            var item = await _context.Tasks.FirstOrDefaultAsync(x => x.Id == newItem.Id);
            if (item == null) throw new ArgumentNullException();
            item.Title = newItem.Title;
            item.Description = newItem.Description;
        }
    }
}
