using BL.Queries.ToDoItems;
using DAL;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.QueryHandlers
{
    public class ToDoItemQueryHandler : 
        IQueryHandler<GetToDoItemQuery, ToDoItem>,
        IQueryHandler<GetItemsFromCategoryQuery, IEnumerable<ToDoItem>>
    {
        private readonly IUnitOfWork _uow;

        public ToDoItemQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ToDoItem Handle(GetToDoItemQuery query)
        {
            var task = _uow.ToDoItemRepository.Get(query.Id);
            if (task.IsCompleted)
            {
                return task.Result;
            }
            throw new NullReferenceException("No items with given id");
        }

        public IEnumerable<ToDoItem> Handle(GetItemsFromCategoryQuery query)
        {
            var items = _uow.ToDoItemRepository.GetItemsFromCategory(query.CategoryId);
            return items;
        }
    }
}
