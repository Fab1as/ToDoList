using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace DAL.Entities
{
    public class ToDoItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        //public FileInfo File { get; set; }
        public int CategoryId { get; set; }
        public DateTime DueTo { get; set; }
        //dropdown with statuses????
    }
}
