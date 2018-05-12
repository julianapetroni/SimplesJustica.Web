﻿using AutoMapper;
using SimplesJustica.Application.Models;
using SimplesJustica.Domain.Entities;

namespace SimplesJustica.Application.AutoMapper
{
    internal class AcusadoProfile : Profile
    {
        internal AcusadoProfile()
        {
            CreateMap<Acusado, AcusadoModel>().ReverseMap();
        }
    }
}
