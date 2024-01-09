using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using Core.Utilities.Result.Abstract;

namespace Business.Repositories.CustomerRealationshipRepository
{
    public interface ICustomerRealationshipService
    {
        Task<IResult> Add(CustomerRealationship customerRealationship);
        Task<IResult> Update(CustomerRealationship customerRealationship);
        Task<IResult> Delete(CustomerRealationship customerRealationship);
        Task<IDataResult<List<CustomerRealationship>>> GetList();
        Task<IDataResult<CustomerRealationship>> GetById(int id);
		Task<IDataResult<CustomerRealationship>> GetByCustomerId(int customerId);
	}
}
