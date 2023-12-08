using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.PriceLİstRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.PriceLİstRepository
{
    public class EfPriceLİstDal : EfEntityRepositoryBase<PriceLİst, SimpleContextDb>, IPriceLİstDal
    {
    }
}
