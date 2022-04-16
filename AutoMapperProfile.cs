using AutoMapper;
using eGertis.Dtos.Items;
using eGertis.Dtos.OrderRequests;
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
            CreateMap<UpdateItemDto, Item>();
            CreateMap<User, GetUserDto>();
            CreateMap<OrderRequest, GetOrderRequestDto>();
        }
    }
}