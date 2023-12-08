using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.PriceLİstRepository
{
    public interface IPriceLİstService
    {
        Task<IResult> Add(PriceLİst priceLİst);
        Task<IResult> Update(PriceLİst priceLİst);
        Task<IResult> Delete(PriceLİst priceLİst);
        Task<IDataResult<List<PriceLİst>>> GetList();
        Task<IDataResult<PriceLİst>> GetById(int id);
    }
}
