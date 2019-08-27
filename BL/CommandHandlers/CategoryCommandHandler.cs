using BL.Commands.Categories;
using DAL;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public Task Handle(CreateCategoryCommand message)
        {
            var category = new Category() { Id = message.Id, Title = message.Title, Description = message.Description };
            _uow.CategoryRepository.Create(category);
            return _uow.Commit();
        }

        public async Task Handle(DeleteCategoryCommand message)
        {
            var category = await _uow.CategoryRepository.Get(message.Id);
            if (category == null) throw new ArgumentNullException();
            _uow.CategoryRepository.Delete(category);

            await _uow.Commit();
        }

        public async Task Handle(UpdateCategoryCommand message)
        {
            var category = new Category() { Id = message.Id, Description = message.Description, Title = message.Title };
            await _uow.CategoryRepository.Update(category);
            await _uow.Commit();
        }
    }
}
