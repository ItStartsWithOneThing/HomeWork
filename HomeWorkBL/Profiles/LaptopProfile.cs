using AutoMapper;
using HomeWork.Models;
using HomeWorkDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkBL.Profiles
{
    public class LaptopProfile : Profile
    {
        public LaptopProfile()
        {
            CreateMap<Laptop, LaptopDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Ram, opt => opt.MapFrom(src => src.Ram))
                .ForMember(dest => dest.Ssd, opt => opt.MapFrom(src => src.Ssd))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Display))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<LaptopDTO, Laptop>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Ram, opt => opt.MapFrom(src => src.Ram))
                .ForMember(dest => dest.Ssd, opt => opt.MapFrom(src => src.Ssd))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Display, opt => opt.MapFrom(src => src.Display))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
