using eCommerceWebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDataController : ControllerBase
    {
        private readonly DataContext _datacontext;

        public CustomerDataController(DataContext context )
        {
            _datacontext = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<CustomerData>>> GetCustomerData()
        {
            return Ok(await _datacontext.Customers.ToListAsync());
        }
    }
}
