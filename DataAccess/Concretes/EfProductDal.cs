using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfProductDal : EfRepositoryBase<Product, Guid, NorthwindContext>, IProductDal
    {
        public EfProductDal(NorthwindContext context) : base(context)
        {
        }
    }
}
