using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
