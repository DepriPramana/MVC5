using AppWeb.Dtos;
using AppWeb.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppWeb.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Domain to Dto
            Mapper.CreateMap<Customers, CustomersDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();


            //Dto to Domain
            Mapper.CreateMap<CustomersDto, Customers>().ForMember(c => c.Id, opt => opt.Ignore());
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}