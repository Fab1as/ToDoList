using BL.Commands.ToDoItem;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Execute(CreateToDoItemCommand message)
        {
            var toDoItem = new ToDoItem() {
                Id = message.Id,
                Title = message.Title,
                Description = message.Description,
                CategoryId = message.CategoryId,
                DueTo = message.DueTo};
            _uow.Context.Tasks.AddAsync(toDoItem);
            _uow.Commit();
        }

        public async void Execute(DeleteToDoItemCommand message)
        {
            var toDoItem = await _uow.Context.Tasks.FirstOrDefaultAsync(x => x.Id == message.Id);
            if (toDoItem == null) throw new ArgumentNullException();
            _uow.Context.Tasks.Remove(toDoItem);
            _uow.Commit();
        }

        public async void Execute(UpdateToDoItemCommand message)
        {
            var toDoItem = await _uow.Context.Tasks.FirstOrDefaultAsync(x => x.Id == message.Id);
            if (toDoItem == null) throw new ArgumentNullException();
            toDoItem.Title = message.Title;
            toDoItem.CategoryId = message.CategoryId;
            toDoItem.DueTo = message.DueTo;
            toDoItem.Description = message.Description;
            _uow.Commit();
        }
    }
}
