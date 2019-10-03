using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using TrainerSystem.Models;
using TrainerSystem.Models.Application;
using TrainerSystem.ViewModels;

namespace TrainerSystem
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {

            Mapper.CreateMap<PackageViewModel, Package>();
            Mapper.CreateMap<Package, PackageViewModel>();

            Mapper.CreateMap<Package, Package>();
            Mapper.CreateMap<PackageViewModel, PackageViewModel>();

            Mapper.CreateMap<ApplicationUser, EditUserViewModel>();
            Mapper.CreateMap<EditUserViewModel, ApplicationUser>();

            Mapper.CreateMap<Customer, Customer>();

            Mapper.CreateMap<Customer, CustomerViewModel>();
            Mapper.CreateMap<CustomerViewModel, Customer>();


            Mapper.CreateMap<Dog, DogViewModel>();
            Mapper.CreateMap<DogViewModel, Dog>();

            Mapper.CreateMap<Race, Race>();
            Mapper.CreateMap<DogSize, DogSize>();
            Mapper.CreateMap<Vaccine, Vaccine>();

            

            //Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            //Mapper.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}