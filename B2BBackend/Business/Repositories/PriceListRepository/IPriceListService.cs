using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.PriceLİstRepository
{
    public interface IPriceListService
    {
        Task<IResult> Add(PriceList priceLİst);
        Task<IResult> Update(PriceList priceLİst);
        Task<IResult> Delete(PriceList priceLİst);
        Task<IDataResult<List<PriceList>>> GetList();
        Task<IDataResult<PriceList>> GetById(int id);
    }
}
