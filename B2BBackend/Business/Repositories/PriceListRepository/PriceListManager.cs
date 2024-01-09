using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.PriceLİstRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.PriceLİstRepository.Validation;
using Business.Repositories.PriceLİstRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.PriceLİstRepository;

namespace Business.Repositories.PriceLİstRepository
{
    public class PriceListManager : IPriceListService
    {
        private readonly IPriceListDal _priceLİstDal;

        public PriceListManager(IPriceListDal priceLİstDal)
        {
            _priceLİstDal = priceLİstDal;
        }

       // [SecuredAspect()]
        [ValidationAspect(typeof(PriceLİstValidator))]
        [RemoveCacheAspect("IPriceLİstService.Get")]

        public async Task<IResult> Add(PriceList priceLİst)
        {
            await _priceLİstDal.Add(priceLİst);
            return new SuccessResult(PriceLİstMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(PriceLİstValidator))]
        [RemoveCacheAspect("IPriceLİstService.Get")]

        public async Task<IResult> Update(PriceList priceLİst)
        {
            await _priceLİstDal.Update(priceLİst);
            return new SuccessResult(PriceLİstMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("IPriceLİstService.Get")]

        public async Task<IResult> Delete(PriceList priceLİst)
        {
            await _priceLİstDal.Delete(priceLİst);
            return new SuccessResult(PriceLİstMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<PriceList>>> GetList()
        {
            return new SuccessDataResult<List<PriceList>>(await _priceLİstDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<PriceList>> GetById(int id)
        {
            return new SuccessDataResult<PriceList>(await _priceLİstDal.Get(p => p.Id == id));
        }

    }
}
