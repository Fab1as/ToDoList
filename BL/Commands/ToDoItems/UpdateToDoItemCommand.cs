using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commands.ToDoItems
{
    public class UpdateToDoItemCommand : ICommand
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        //public FileInfo File { get; }
        public int CategoryId { get; }
        public DateTime DueTo { get; }

        public UpdateToDoItemCommand(int id, string title, string description, int categoryId, DateTime dueTo)
        {
            Id = id;
            Title = title;
            Description = description;
            CategoryId = categoryId;
            DueTo = dueTo;
        }
    }
}
