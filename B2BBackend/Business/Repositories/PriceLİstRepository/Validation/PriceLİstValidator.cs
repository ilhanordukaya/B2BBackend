using System;
using System.Collections.Generic;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Business.Repositories.PriceLİstRepository.Validation
{
    public class PriceLİstValidator : AbstractValidator<PriceLİst>
    {
        public PriceLİstValidator()
        {
        }
    }
}
