using AutoMapper;
using ReviewApp.Dto;
using ReviewApp.Models;

namespace ReviewApp.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
