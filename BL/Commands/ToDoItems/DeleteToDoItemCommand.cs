using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commands.ToDoItems
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
