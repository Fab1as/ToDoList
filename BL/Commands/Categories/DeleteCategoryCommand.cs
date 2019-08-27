using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commands.Categories
{
    public class DeleteCategoryCommand : ICommand
    {
        public int Id { get; }

        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }
    }
}
