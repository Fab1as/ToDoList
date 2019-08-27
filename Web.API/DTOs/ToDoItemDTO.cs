using System;
using System.Collections.Generic;
using System.Text;
using static DAL.Entities.ToDoItem;

namespace Web.API.DTOs
{
    public class ToDoItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; }
        public int CategoryId { get; set; }
        public DateTime DueTo { get; set; }
        public StatusEnum Status { get; set; }
    }
}
