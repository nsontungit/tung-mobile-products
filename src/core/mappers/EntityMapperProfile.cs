using AutoMapper;
using core.models;
using entities.main;
using System;
using System.Collections.Generic;
using System.Text;

namespace core.mappers
{
    public class EntityMapperProfile : Profile
    {
        public EntityMapperProfile()
        {
            CreateMap<LaptopDto, Laptop>();
        }
    }
}
