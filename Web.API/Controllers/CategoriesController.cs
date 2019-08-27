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
using BL.Commands.Categories;
using BL.QueryHandlers;
using BL.Queries.Categories;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryCommandHandler _commandHandler;
        private readonly CategoryQueryHandler _queryHandler;

        public CategoriesController(
            CategoryCommandHandler commandHandler,
            CategoryQueryHandler queryHandler)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
        }

        //GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetCategories()
        {
            var query = new GetAllCategoriesQuery();
            var categories = _queryHandler.Handle(query);
            return Ok(categories);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<Category> GetCategory(int id)
        {
            var query = new GetCategoryQuery(id);
            var category = _queryHandler.Handle(query);

            return Ok(category);
        }

        // PUT: api/Categories/5
        [HttpPut]
        public async Task<IActionResult> EditCategory(Category category)
        {
            var command = new UpdateCategoryCommand(category.Id, category.Title, category.Description);

            await _commandHandler.Handle(command);

            return Ok();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<Category>> AddCategory(Category category)
        {
            var command = new CreateCategoryCommand(category.Id, category.Title, category.Description);

            await _commandHandler.Handle(command);

            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);

            await _commandHandler.Handle(command);

            return Ok();
        }
    }
}
