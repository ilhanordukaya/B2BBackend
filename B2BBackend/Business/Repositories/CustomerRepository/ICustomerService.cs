using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;

namespace Business.Repositories.CustomerRepository
{
    public interface ICustomerService
    {
        Task<IResult> Add(CustomerRegisterDto customerRegisterDto);
        Task<IResult> Update(Customer customer);
        Task<IResult> Delete(Customer customer);
       
        Task<IDataResult<Customer>> GetById(int id);
		Task<Customer> GetByEmail(string email);
		Task<IResult> ChangePasswordByAdminPanel(CustomerChangePassworByAdminPanelDto customerDto);
		Task<IDataResult<List<CustomerDto>>> GetList();
		Task<IDataResult<CustomerDto>> GetDtoById(int id);
	}
}
