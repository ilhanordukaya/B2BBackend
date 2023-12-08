using Business.Repositories.CustomerRealationshipRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerRealationshipsController : ControllerBase
    {
        private readonly ICustomerRealationshipService _customerRealationshipService;

        public CustomerRealationshipsController(ICustomerRealationshipService customerRealationshipService)
        {
            _customerRealationshipService = customerRealationshipService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(CustomerRealationship customerRealationship)
        {
            var result = await _customerRealationshipService.Add(customerRealationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(CustomerRealationship customerRealationship)
        {
            var result = await _customerRealationshipService.Update(customerRealationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(CustomerRealationship customerRealationship)
        {
            var result = await _customerRealationshipService.Delete(customerRealationship);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _customerRealationshipService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _customerRealationshipService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
