using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using DataAccess.Repositories.CustomerRealationshipRepository;
using DataAccess.Context.EntityFramework;

namespace DataAccess.Repositories.CustomerRealationshipRepository
{
    public class EfCustomerRealationshipDal : EfEntityRepositoryBase<CustomerRealationship, SimpleContextDb>, ICustomerRealationshipDal
    {
    }
}
