using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL.Queries.Categories
{
    public class GetCategoryQuery : IQuery<Category>
    {
        public int Id { get; }

        public GetCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
