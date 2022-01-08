using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eGertis.Dtos.Item;
using eGertis.Dtos.SailCamp;
using eGertis.Dtos.User;
using eGertis.Models;

namespace eGertis
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddItemDto, Item>();
            CreateMap<Item, GetItemDto>();
            CreateMap<UpdateItemDto, Item>();
            CreateMap<SailCamp, GetSailCampDto>();
            CreateMap<CreateSailCampDto, SailCamp>();
            CreateMap<UpdateSailCampDto, SailCamp>();
            CreateMap<User, GetUserDto>();
        }
    }
}