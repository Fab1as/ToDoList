using BL.Commands.ToDoItems;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.CommandHandlers
{
    public class ToDoItemCommandHandler :
        ICommandHandler<CreateToDoItemCommand>,
        ICommandHandler<DeleteToDoItemCommand>,
        ICommandHandler<UpdateToDoItemCommand>
    {
        private readonly IUnitOfWork _uow;

        public ToDoItemCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Task Handle(CreateToDoItemCommand message)
        {
            var toDoItem = new ToDoItem() {
                Id = message.Id,
                Title = message.Title,
                Description = message.Description,
                CategoryId = message.CategoryId,
                DueTo = message.DueTo};
            _uow.ToDoItemRepository.Create(toDoItem);
            return _uow.Commit();
        }

        public async Task Handle(DeleteToDoItemCommand message)
        {
            var toDoItem = await _uow.ToDoItemRepository.Get(message.Id);
            if (toDoItem == null) throw new ArgumentNullException();
            _uow.ToDoItemRepository.Delete(toDoItem);
            await _uow.Commit();
        }

        public async Task Handle(UpdateToDoItemCommand message)
        {
            var toDoItem = new ToDoItem()
            {
                Id = message.Id,
                CategoryId = message.CategoryId,
                Description = message.Description,
                Title = message.Title,
                DueTo = message.DueTo
            };
            
            await _uow.Commit();
        }
    }
}
