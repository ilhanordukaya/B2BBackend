using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.OrderDetailRepository
{
	public interface IOrderDetailDal : IEntityRepository<OrderDetail>
	{
		Task<List<OrderDetailDto>> GetListDto(int orderId);
	}
}
