using BL.Interfaces;
using BL.Queries.Categories;
using DAL;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace BL.QueryHandlers
{
    public class CategoryQueryHandler :
        IQueryHandler<GetCategoryQuery, Category>,
        IQueryHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly IUnitOfWork _uow;

        public CategoryQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Category Handle(GetCategoryQuery query)
        {
            var task = _uow.CategoryRepository.Get(query.Id);
            if (task.IsCompleted)
            {
                return task.Result;
            }
            throw new NullReferenceException("No categories with given id");
        }

        public IEnumerable<Category> Handle(GetAllCategoriesQuery query)
        {
            var categories = _uow.CategoryRepository.GetAll();
            return categories;
        }
    }
}
