using AutoMapper;
using eGertis.Dtos.Items;
using eGertis.Dtos.ItemWrappers;
using eGertis.Dtos.Users;
using eGertis.Models;

namespace eGertis
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<AddItemDto, Item>();
            CreateMap<Item, GetItemDto>();
            CreateMap<GetItemDto, Item>();
            CreateMap<UpdateItemDto, Item>();
            CreateMap<User, GetUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<CreateItemWrapperDto, ItemWrapper>();
        }
    }
}