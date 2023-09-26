using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDataController : ControllerBase
    {
        [HttpGet]

        public async Task<ActionResult<List<CustomerData>>> GetCustomerData()
        {
            return new List<CustomerData>
            {
                new CustomerData
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "jDoe69@gmail.com"
                }
            };
        }
    }
}
