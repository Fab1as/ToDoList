using BL.Interfaces;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Queries.ToDoItems
{
    public class GetItemsFromCategoryQuery : IQuery<IEnumerable<ToDoItem>>
    {
        public int CategoryId { get; }

        public GetItemsFromCategoryQuery(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
