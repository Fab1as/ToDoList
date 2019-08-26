using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }
    }
}
