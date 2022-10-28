using AutoMapper;
using Onion.Core.Commands.Customers;
using Onion.Core.Models.ViewModels;
using Onion.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.App.Mapping
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            //CreateMap<CreateCustomerCommand, Customer>()
            //    .ForMember(cfg => cfg.Address.State, act => act.MapFrom(src => src.State))
            //    .ForMember(cfg => cfg.Address.Country, act => act.MapFrom(src => src.Country))
            //    .ForMember(cfg => cfg.Address.Street, act => act.MapFrom(src => src.Street))
            //    .ForMember(cfg => cfg.Address.Zipcode, act => act.MapFrom(src => src.Zipcode))
            //    .ForMember(cfg => cfg.Address.City, act => act.MapFrom(src => src.City));

            //CreateMap<UpdateCustomerCommand, Customer>()
            //    .ForMember(cfg => cfg.Address.State, act => act.MapFrom(src => src.State))
            //    .ForMember(cfg => cfg.Address.Country, act => act.MapFrom(src => src.Country))
            //    .ForMember(cfg => cfg.Address.Street, act => act.MapFrom(src => src.Street))
            //    .ForMember(cfg => cfg.Address.Zipcode, act => act.MapFrom(src => src.Zipcode))
            //    .ForMember(cfg => cfg.Address.City, act => act.MapFrom(src => src.City));

            //CreateMap<CustomerContactCommand, CustomerContact>();

            CreateMap<Customer, CustomerVm>()
                .ForMember(cfg => cfg.State, act => act.MapFrom(src => src.Address.State))
                .ForMember(cfg => cfg.Country, act => act.MapFrom(src => src.Address.Country))
                .ForMember(cfg => cfg.Street, act => act.MapFrom(src => src.Address.Street))
                .ForMember(cfg => cfg.Zipcode, act => act.MapFrom(src => src.Address.Zipcode))
                .ForMember(cfg => cfg.City, act => act.MapFrom(src => src.Address.City));

            CreateMap<CustomerContact, CustomerContactVm>();

        }
    }
}
