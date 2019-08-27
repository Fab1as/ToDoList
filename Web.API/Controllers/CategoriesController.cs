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
using Web.API.DTOs;
using AutoMapper;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryCommandHandler _commandHandler;
        private readonly CategoryQueryHandler _queryHandler;
        private readonly IMapper _mapper;

        public CategoriesController(
            CategoryCommandHandler commandHandler,
            CategoryQueryHandler queryHandler,
            IMapper mapper)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
            _mapper = mapper;
        }

        //GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<CategoryDTO>> GetCategories()
        {
            var query = new GetAllCategoriesQuery();
            var categories = _queryHandler.Handle(query);
            var itemsDTO = _mapper.Map<IEnumerable<CategoryDTO>>(categories);
            return Ok(itemsDTO);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<CategoryDTO> GetCategory(int id)
        {
            var query = new GetCategoryQuery(id);
            var category = _queryHandler.Handle(query);
            var categoryDTO = _mapper.Map<CategoryDTO>(category);

            return Ok(categoryDTO);
        }

        // PUT: api/Categories/5
        [HttpPut]
        public async Task<IActionResult> EditCategory(CategoryDTO category)
        {
            var command = new UpdateCategoryCommand(category.Id, category.Title, category.Description);

            await _commandHandler.HandleAsync(command);

            return Ok();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult> AddCategory(CategoryDTO category)
        {
            var command = new CreateCategoryCommand(category.Id, category.Title, category.Description);

            await _commandHandler.HandleAsync(command);

            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var command = new DeleteCategoryCommand(id);

            await _commandHandler.HandleAsync(command);

            return Ok();
        }
    }
}
