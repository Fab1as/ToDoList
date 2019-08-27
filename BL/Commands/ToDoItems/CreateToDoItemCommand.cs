using BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using static DAL.Entities.ToDoItem;

namespace BL.Commands.ToDoItems
{
    public class CreateToDoItemCommand : ICommand
    {
        public int Id { get; }
        public string Title { get; }
        public string Description { get; }
        public string Path { get; }
        public int CategoryId { get; }
        public DateTime DueTo { get; }
        public StatusEnum Status { get; }


        public CreateToDoItemCommand(
            int id,
            string title,
            string description,
            int categoryId,
            DateTime dueTo,
            StatusEnum status,
            string path)
        {
            Id = id;
            Title = title;
            Description = description;
            CategoryId = categoryId;
            DueTo = dueTo;
            Status = status;
            Path = path;
        }
    }
}
