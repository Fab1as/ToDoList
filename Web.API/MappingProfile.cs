using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.DTOs;

namespace Web.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<ToDoItem, ToDoItemDTO>();
            CreateMap<ToDoItemDTO, ToDoItem>();
        }
    }
}
