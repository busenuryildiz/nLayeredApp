using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Business.Messages;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concretes
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IMapper _mapper;
        CustomerBusinessRules _businessRules;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper, CustomerBusinessRules businessRules)
        {
            _customerDal = customerDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedCustomerResponse> Add(CreateCustomerRequest createCustomerRequest)
        {
            await _businessRules.ContactNameCantRepeat(createCustomerRequest.ContactName);
            await _businessRules.EachCityCanContainMax10Customers(createCustomerRequest.City);
            Customer customer = _mapper.Map<Customer>(createCustomerRequest);
            Customer createdCustomer = await _customerDal.AddAsync(customer);
            CreatedCustomerResponse createdCustomerResponse = _mapper.Map<CreatedCustomerResponse>(createdCustomer);
            return createdCustomerResponse;
        }

        public async Task<DeletedCustomerResponse> Delete(DeleteCustomerRequest deleteCustomerRequest)
        {
            var data = await _customerDal.GetAsync(i => i.Id == deleteCustomerRequest.Id);
            _mapper.Map(deleteCustomerRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _customerDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedCustomerResponse>(result);
            return result2;
        }
        public async Task<IPaginate<GetListCustomerResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _customerDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListCustomerResponse>>(data);
            return result;
        }

        public async Task<UpdatedCustomerResponse> Update(UpdateCustomerRequest updateCustomerRequest)
        {
            var data = await _customerDal.GetAsync(i => i.Id == updateCustomerRequest.Id);
            _mapper.Map(updateCustomerRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _customerDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedCustomerResponse>(data);
            return result;
        }
        public async Task<CreatedCustomerResponse> GetById(string id)
        {
            var result = await _customerDal.GetAsync(c => c.Id == id);
            Customer mappedCustomer = _mapper.Map<Customer>(result);

            CreatedCustomerResponse createdCustomerResponse = _mapper.Map<CreatedCustomerResponse>(mappedCustomer);

            return createdCustomerResponse;
        }
    }
}
