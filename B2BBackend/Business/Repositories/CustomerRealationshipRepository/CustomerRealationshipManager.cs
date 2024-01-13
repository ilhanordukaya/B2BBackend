using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.CustomerRealationshipRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.CustomerRealationshipRepository.Validation;
using Business.Repositories.CustomerRealationshipRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CustomerRealationshipRepository;

namespace Business.Repositories.CustomerRealationshipRepository
{
    public class CustomerRealationshipManager : ICustomerRealationshipService
    {
        private readonly ICustomerRealationshipDal _customerRealationshipDal;

        public CustomerRealationshipManager(ICustomerRealationshipDal customerRealationshipDal)
        {
            _customerRealationshipDal = customerRealationshipDal;
        }

       // [SecuredAspect()]
        [ValidationAspect(typeof(CustomerRealationshipValidator))]
        [RemoveCacheAspect("ICustomerRealationshipService.Get")]

        public async Task<IResult> Add(CustomerRealationship customerRealationship)
        {
            await _customerRealationshipDal.Add(customerRealationship);
            return new SuccessResult(CustomerRealationshipMessages.Added);
        }

        [SecuredAspect()]
        [ValidationAspect(typeof(CustomerRealationshipValidator))]
        [RemoveCacheAspect("ICustomerRealationshipService.Get")]

        public async Task<IResult> Update(CustomerRealationship customerRealationship)
        {
			var result = await _customerRealationshipDal.Get(p => p.CustomerId == customerRealationship.CustomerId);
			if (result != null)
			{
				customerRealationship.Id = result.Id;
				await _customerRealationshipDal.Update(customerRealationship);
			}
			else
			{
				await _customerRealationshipDal.Add(customerRealationship);
			}

			return new SuccessResult(CustomerRealationshipMessages.Updated);
		}

        [SecuredAspect()]
        [RemoveCacheAspect("ICustomerRealationshipService.Get")]

        public async Task<IResult> Delete(CustomerRealationship customerRealationship)
        {
            await _customerRealationshipDal.Delete(customerRealationship);
            return new SuccessResult(CustomerRealationshipMessages.Deleted);
        }

        [SecuredAspect()]
        [CacheAspect()]
        [PerformanceAspect()]
        public async Task<IDataResult<List<CustomerRealationship>>> GetList()
        {
            return new SuccessDataResult<List<CustomerRealationship>>(await _customerRealationshipDal.GetAll());
        }

        [SecuredAspect()]
        public async Task<IDataResult<CustomerRealationship>> GetById(int id)
        {
            return new SuccessDataResult<CustomerRealationship>(await _customerRealationshipDal.Get(p => p.Id == id));
        }

		[SecuredAspect()]
		public async Task<IDataResult<CustomerRealationship>> GetByCustomerId(int customerId)
		{
			return new SuccessDataResult<CustomerRealationship>(await _customerRealationshipDal.Get(p => p.CustomerId == customerId));
		}

	}
}
