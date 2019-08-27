using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Queries.ToDoItems
{
    public class GetToDoItemQuery : IQuery<ToDoItem>
    {
        public int Id { get; }

        public GetToDoItemQuery(int id)
        {
            Id = id;
        }
    }
}
