using BL.Queries.Categories;
using DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.QueryHandlers
{
    class CategoryQueryHandler :
        IQueryHandler<GetCategoryQuery, DAL.Entities.Category>,
        IQueryHandler<GetAllCategoriesQuery, IEnumerable<DAL.Entities.Category>>
    {
        private readonly IUnitOfWork _uow;

        public CategoryQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public DAL.Entities.Category Handle(GetCategoryQuery query)
        {
            var task = _uow.CategoryRepository.Get(query.Id);
            if (task.IsCompleted)
            {
                return task.Result;
            }
            throw new NullReferenceException("No categories with given id");
        }

        public IEnumerable<DAL.Entities.Category> Handle(GetAllCategoriesQuery query)
        {
            var categories = _uow.CategoryRepository.GetAll();
            return categories;
        }
    }
}
