using AutoMapper;
using eGertis.Dtos.Item;
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
            CreateMap<User, GetUserDto>();
        }
    }
}