using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Repositories.CustomerRepository;
using Entities.Concrete;
using Business.Aspects.Secured;
using Core.Aspects.Validation;
using Core.Aspects.Caching;
using Core.Aspects.Performance;
using Business.Repositories.CustomerRepository.Validation;
using Business.Repositories.CustomerRepository.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Repositories.CustomerRepository;
using Entities.Dtos;
using Core.Utilities.Hashing;
using DataAccess.Repositories.CustomerRealationshipRepository;
using Business.Repositories.CustomerRealationshipRepository;
using Business.Repositories.OrderRepository;
using Core.Utilities.Business;

namespace Business.Repositories.CustomerRepository
{
    public class CustomerManager : ICustomerService
	{
        private readonly ICustomerDal _customerDal;
		private readonly ICustomerRealationshipService _customerRealationshipService;
		private readonly IOrderService _orderService;


		public CustomerManager(ICustomerDal customerDal, ICustomerRealationshipService customerRealationshipService, IOrderService orderService)
		{
			_customerDal = customerDal;
			_customerRealationshipService = customerRealationshipService;
			_orderService = orderService;
		}

		//[SecuredAspect()]
		[ValidationAspect(typeof(CustomerValidator))]
        [RemoveCacheAspect("ICustomerService.Get")]

        public async Task<IResult> Add(CustomerRegisterDto customerRegisterDto)
        {
			IResult result = BusinessRules.Run(
               await CheckIfEmailExists(customerRegisterDto.Email)
               );

			if (result != null)
			{
				return result;
			}

			byte[] passwordHash, paswordSalt;
			HashingHelper.CreatePassword(customerRegisterDto.Password, out passwordHash, out paswordSalt);

			Customer customer = new Customer()
			{
				Id = 0,
				Email = customerRegisterDto.Email,
				Name = customerRegisterDto.Name,
				PasswordHash = passwordHash,
				PasswordSalt = paswordSalt,
			};

			await _customerDal.Add(customer);
			return new SuccessResult(CustomerMessages.Added);
		}
		public async Task<Customer> GetByEmail(string email)
		{
			var result = await _customerDal.Get(p => p.Email == email);
			return result;
		}

		[SecuredAspect()]
        [ValidationAspect(typeof(CustomerValidator))]
        [RemoveCacheAspect("ICustomerService.Get")]

        public async Task<IResult> Update(Customer customer)
        {
            await _customerDal.Update(customer);
            return new SuccessResult(CustomerMessages.Updated);
        }

        [SecuredAspect()]
        [RemoveCacheAspect("ICustomerService.Get")]

        public async Task<IResult> Delete(Customer customer)
        {
			IResult result = BusinessRules.Run(
			   await CheckIfCustomerOrderExist(customer.Id));

			if (result != null)
			{
				return result;
			}

			var customerRelationship = await _customerRealationshipService.GetByCustomerId(customer.Id);
			if (customerRelationship.Data != null)
			{
				await _customerRealationshipService.Delete(customerRelationship.Data);
			}

			await _customerDal.Delete(customer);
			return new SuccessResult(CustomerMessages.Deleted);
		}

		[SecuredAspect()]
		[CacheAspect()]
		[PerformanceAspect()]
		public async Task<IDataResult<List<CustomerDto>>> GetList()
		{
			return new SuccessDataResult<List<CustomerDto>>(await _customerDal.GetListDto());
		}

		[SecuredAspect()]
        public async Task<IDataResult<Customer>> GetById(int id)
        {
            return new SuccessDataResult<Customer>(await _customerDal.Get(p => p.Id == id));
        }

		[SecuredAspect()]
		public async Task<IDataResult<CustomerDto>> GetDtoById(int id)
		{
			return new SuccessDataResult<CustomerDto>(await _customerDal.GetDto(id));
		}

		private async Task<IResult> CheckIfEmailExists(string email)
		{
			var list = await GetByEmail(email);
			if (list != null)
			{
				return new ErrorResult("Bu mail adresi daha önce kullanýlmýþ");
			}
			return new SuccessResult();
		}

		public async Task<IResult> CheckIfCustomerOrderExist(int customerId)
		{
			var result = await _orderService.GetListByCustomerId(customerId);
			if (result.Data.Count > 0)
			{
				return new ErrorResult("Sipariþi bulunan müþteri kaydý silinemez!");
			}
			return new SuccessResult();
		}

		[SecuredAspect()]
		public async Task<IResult> ChangePasswordByAdminPanel(CustomerChangePassworByAdminPanelDto customerDto)
		{
			byte[] passwordHash, passwordSalt;
			HashingHelper.CreatePassword(customerDto.Password, out passwordHash, out passwordSalt);
			var customer = await _customerDal.Get(p => p.Id == customerDto.Id);
			customer.PasswordHash = passwordHash;
			customer.PasswordSalt = passwordSalt;

			await _customerDal.Update(customer);
			return new SuccessResult(CustomerMessages.ChangedPassword);
		}

	}
}
