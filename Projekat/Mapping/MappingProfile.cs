using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Projekat.Dto;
using Projekat.Models;

namespace Projekat.Mapping
{
	public class MappingProfile : Profile
	{
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap(); //Kazemo mu da mapira Subject na SubjectDto i obrnuto
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<Order,OrderDto>().ReverseMap();
        }
    }
}
