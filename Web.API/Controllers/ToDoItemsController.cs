using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BL.CommandHandlers;
using BL.Commands.ToDoItems;
using BL.Queries.ToDoItems;
using BL.QueryHandlers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web.API.DTOs;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoItemCommandHandler _commandHandler;
        private readonly ToDoItemQueryHandler _queryHandler;
        private readonly IMapper _mapper;
        private readonly IHostingEnvironment _appEnvironment;

        public ToDoItemsController(
            ToDoItemCommandHandler commandHandler,
            ToDoItemQueryHandler queryHandler,
            IMapper mapper,
            IHostingEnvironment appEnvironment)
        {
            _commandHandler = commandHandler;
            _queryHandler = queryHandler;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
        }

        //GET: api/Categories
        [HttpGet]
        public ActionResult<IEnumerable<ToDoItemDTO>> GetItemFromCategory(int categoryId)
        {
            var query = new GetItemsFromCategoryQuery(categoryId);
            var items = _queryHandler.Handle(query);
            var itemsDTO = _mapper.Map<IEnumerable<ToDoItemDTO>>(items);
            return Ok(itemsDTO);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public ActionResult<ToDoItemDTO> GetItem(int id)
        {
            var query = new GetToDoItemQuery(id);
            var item = _queryHandler.Handle(query);
            var itemDTO = _mapper.Map<ToDoItemDTO>(item);

            return Ok(itemDTO);
        }

        // PUT: api/Categories/5
        [HttpPut]
        public async Task<IActionResult> EditItem(ToDoItemDTO item)
        {
            var command = new UpdateToDoItemCommand(
                item.Id, 
                item.Title, 
                item.Description,
                item.CategoryId, 
                item.DueTo,
                item.Status,
                item.Path);

            await _commandHandler.HandleAsync(command);


            return Ok();
        }

        // POST: api/Categories
        [HttpPost]
        public async Task<ActionResult> AddItem(ToDoItemDTO item)
        {
            var command = new CreateToDoItemCommand(
                item.Id,
                item.Title,
                item.Description,
                item.CategoryId,
                item.DueTo,
                item.Status,
                item.Path);

            await _commandHandler.HandleAsync(command);

            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(int id)
        {
            var command = new DeleteToDoItemCommand(id);

            await _commandHandler.HandleAsync(command);

            return Ok();
        }

        [HttpPost]
        public ActionResult UploadFile(string path, IFormFile file)
        {
            if (!Directory.Exists(path))
            {
                DirectoryInfo di = Directory.CreateDirectory(path);
            }

            if (file != null)
            {
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyToAsync(fileStream);
                }
                return Ok();
            }

            return StatusCode(500);
        }
    }
}