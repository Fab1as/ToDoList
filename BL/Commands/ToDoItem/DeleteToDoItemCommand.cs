using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commands.ToDoItem
{
    public class DeleteToDoItemCommand : ICommand
    {
        public int Id { get; }

        public DeleteToDoItemCommand(int id)
        {
            Id = id;
        }
    }
}
