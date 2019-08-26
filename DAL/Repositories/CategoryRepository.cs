using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task Create(Category category)
        {
            return _context.Categories.AddAsync(category);
        }

        public void Delete(Category category)
        { 
            _context.Categories.Remove(category);
        }

        public Task<Category> Get(int id)
        {
            return _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public async Task Update(Category category)
        {
            var item = await _context.Categories.FirstOrDefaultAsync(x => x.Id == category.Id);
            if (item == null) throw new ArgumentNullException();
            item.Title = category.Title;
            item.Description = category.Description;
        }
    }
}
