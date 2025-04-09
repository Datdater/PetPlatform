using AutoMapper;
using Product.Application.Feature.Products.Commands.CreateProduct;
using Product.Application.Feature.Products.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<CreateProductCommand, Domain.Entities.Product>().ReverseMap();
            CreateMap<ProductDetailDTO, Domain.Entities.Product>().ReverseMap();
        }
    }
}
