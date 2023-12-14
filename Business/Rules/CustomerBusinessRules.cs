using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Messages;
using Core.Business.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class CustomerBusinessRules:BaseBusinessRules
    {
        private readonly ICustomerDal _customerDal;

        public CustomerBusinessRules(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task EachCityCanContainMax10Customers(string city)
        {
            var result = await _customerDal.GetListAsync(c => c.City == city);
            if (result.Count >= 10)
            {
                throw new BusinessException(BusinessMessages.CustomerLimitInCity);
            }
        }
        public async Task ContactNameCantRepeat(string contactName)
        {
            var result = await _customerDal.GetListAsync(
                predicate: c => c.ContactName == contactName
            );
            if (result.Count >= 1)
            {
                throw new BusinessException(BusinessMessages.ContactNameCantRepeat);
            }

        }
    }
}
