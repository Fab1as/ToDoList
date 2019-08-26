using BL.Commands;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.CommandHandlers
{
    public class CategoryCommandHandler : 
        ICommandHandler<CreateCategoryCommand>,
        ICommandHandler<DeleteCategoryCommand>,
        ICommandHandler<UpdateCategoryCommand>
    {
        private readonly IUnitOfWork _uow;

        public CategoryCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void Execute(CreateCategoryCommand message)
        {
            var category = new Category() { Id = message.Id, Title = message.Title, Description = message.Description };
            _uow.Context.Categories.AddAsync(category);
            _uow.Commit();
        }

        public async void Execute(DeleteCategoryCommand message)
        {
            var category = await _uow.Context.Categories.FirstOrDefaultAsync(x => x.Id == message.Id);
            if (category == null) throw new ArgumentNullException();
            _uow.Context.Categories.Remove(category);
            _uow.Commit();
        }

        public async void Execute(UpdateCategoryCommand message)
        {
            var category = await _uow.Context.Categories.FirstOrDefaultAsync(x => x.Id == message.Id);
            if (category == null) throw new ArgumentNullException();
            category.Title = message.Title;
            category.Description = message.Description;
            _uow.Commit();
        }
    }
}
