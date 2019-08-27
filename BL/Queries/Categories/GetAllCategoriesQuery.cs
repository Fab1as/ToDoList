using System;
using System.Collections.Generic;
using System.Text;
using BL.Interfaces;
using DAL.Entities;

namespace BL.Queries.Categories
{
    public class GetAllCategoriesQuery : IQuery<IEnumerable<Category>>
    {
    }
}
