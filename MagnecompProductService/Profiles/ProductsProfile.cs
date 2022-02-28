using AutoMapper;
using MagnecompProductService.Dtos;
using MagnecompProductService.Models;

namespace MagnecompProductService.Profiles
{
  public class ProductProfile : Profile
  {
    public ProductProfile()
    {
      // Source -> Target
      CreateMap<Product, ProductReadDto>();
      CreateMap<ProductCreateDto, Product>();
    }
  }
}