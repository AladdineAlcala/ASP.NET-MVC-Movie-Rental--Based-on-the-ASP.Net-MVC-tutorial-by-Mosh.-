using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Domain to Dto
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Movie, MovieDTO>();
            CreateMap<MembershipType, MembershiptypDTO>();
            CreateMap<Genre, GenreDTO>();

            ////Dto to Domain
            CreateMap<CustomerDTO, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MovieDTO, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<MembershiptypDTO, MembershipType>();
            CreateMap<GenreDTO, Genre>();
        }
    }
}