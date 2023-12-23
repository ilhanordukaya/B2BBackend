using Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
	public interface ITokenHandler
	{
		AdminToken CreateToken(User user, List<OperationClaim> operationClaims);
		CustomerToken CreateCustomerToken(Customer customer);
	}
}
