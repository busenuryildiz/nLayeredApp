using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests;
using Business.Dtos.Responses;

namespace Business.Abstracts
{
    public interface IProductService
    {
        Task<IPaginate<GetListProductResponse>> GetListAsync();
        Task<CreatedProductResponse> Add(CreateProductRequest createProductRequest);

    }
}
