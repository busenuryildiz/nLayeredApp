using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;

namespace Business.Concretes
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        IMapper _mapper;


        public CategoryManager(ICategoryDal categoryDal, IMapper mapper)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
        }

        public async Task<IPaginate<GetListCategoryResponse>> GetListAsync()
        {
            var categoryList = await _categoryDal.GetListAsync();
            var mappedList = _mapper.Map<Paginate<GetListCategoryResponse>>(categoryList);
            return mappedList;
        }

        public async Task<CreatedCategoryResponse> Add(CreateCategoryRequest createCategoryRequest)
        {
            Category category = _mapper.Map<Category>(createCategoryRequest);
            Category createdCategory = await _categoryDal.AddAsync(category);
            CreatedCategoryResponse createdCategoryResponse = _mapper.Map<CreatedCategoryResponse>(createdCategory);
            return createdCategoryResponse;
        }

    }
}
