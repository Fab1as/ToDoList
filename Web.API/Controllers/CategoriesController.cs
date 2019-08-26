using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using BL.CommandHandlers;
using BL.Commands;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly CategoryCommandHandler _commandHandler;

        public CategoriesController(IUnitOfWork uow, CategoryCommandHandler commandHandler)
        {
            _uow = uow;
            _commandHandler = commandHandler;
        }

        // GET: api/Categories
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
        //{
        //    return await _context.Categories.ToListAsync();
        //}

        // GET: api/Categories/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Category>> GetCategory(int id)
        //{
        //    var category = await _context.Categories.FindAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}

        // PUT: api/Categories/5
        [HttpPut]
        public async Task<IActionResult> EditCategory(Category category)
        {
            var command = new UpdateCategoryCommand(category.Id, category.Title, category.Description);

            _commandHandler.Execute(command);

            return Ok();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            var command = new CreateCategoryCommand(category.Id, category.Title, category.Description);

            _commandHandler.Execute(command);

            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);

            _commandHandler.Execute(command);

            return Ok();
        }

        //private bool CategoryExists(int id)
        //{
        //    return _context.Categories.Any(e => e.Id == id);
        //}
    }
}
