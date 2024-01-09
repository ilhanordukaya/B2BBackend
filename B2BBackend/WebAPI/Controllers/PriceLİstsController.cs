using Business.Repositories.PriceLİstRepository;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceLİstsController : ControllerBase
    {
        private readonly IPriceListService _priceLİstService;

        public PriceLİstsController(IPriceListService priceLİstService)
        {
            _priceLİstService = priceLİstService;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(PriceList priceLİst)
        {
            var result = await _priceLİstService.Add(priceLİst);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update(PriceList priceLİst)
        {
            var result = await _priceLİstService.Update(priceLİst);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(PriceList priceLİst)
        {
            var result = await _priceLİstService.Delete(priceLİst);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetList()
        {
            var result = await _priceLİstService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _priceLİstService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
