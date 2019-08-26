using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commands.ToDoItem
{
    public class CreateToDoItemCommand : ICommand
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        //public FileInfo File { get; }
        public int CategoryId { get; }
        public DateTime DueTo { get; }

        public CreateToDoItemCommand(int id, string title, string description, int categoryId, DateTime dueTo)
        {
            Id = id;
            Title = title;
            Description = description;
            CategoryId = categoryId;
            DueTo = dueTo;
        }
    }
}
