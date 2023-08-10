using AutoMapper;
using OakleyShop.Domain.Entities;
using OakleyShop.Domain.OutputModels;

namespace OakleyShop.CrossCutting.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Product, ProductOutputModel>()
                .ReverseMap();

            CreateMap<Category, CategoryOutputModel>()
                .ReverseMap();

        }
    }
}
