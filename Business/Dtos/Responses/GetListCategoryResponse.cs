using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses;
public class GetListCategoryResponse : BasePageableModel
{
    public IList<CategoryListDto> Items { get; set; }
}
public class CategoryListDto
{
    public string Name { get; set; }
    public string Description { get; set; }
}

