﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class CategoryBusinessRules:BaseBusinessRules
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryBusinessRules(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public async Task MaximumCategoryCountIsTen()
        {
            var result= await _categoryDal.GetListAsync();

            if (result.Count>=10)
            {
                throw new Exception("Kategori sayısı max 10 olabilir");
            }
        }
    }
}
