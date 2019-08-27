using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Commands.Categories
{
    public class UpdateCategoryCommand : ICommand
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }

        public UpdateCategoryCommand(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
