using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using Entities.Concretes;

namespace Business.Dtos.Profiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<CreateCustomerRequest, Customer>().ReverseMap();
            CreateMap<Customer, DeleteCustomerRequest>().ReverseMap();
            CreateMap<UpdateCustomerRequest, Customer>().ReverseMap();

            CreateMap<Customer, CreatedCustomerResponse>().ReverseMap();
            CreateMap<Customer, DeletedCustomerResponse>().ReverseMap();
            CreateMap<UpdatedCustomerResponse, Customer>().ForMember(dest => dest.CreatedDate, opt => opt.Ignore()).ReverseMap();

            CreateMap<Customer, GetListCustomerResponse>().ReverseMap();
            CreateMap<Paginate<Customer>, Paginate<GetListCustomerResponse>>().ReverseMap();

        }
    }
}
