using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerceWebAPI.Data;
using eCommerceWebAPI.Model;

namespace eCommerceWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDatasController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerDatasController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CustomerDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerData>>> GetCustomers()
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            return await _context.Customers.ToListAsync();
        }

        // GET: api/CustomerDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerData>> GetCustomerData(int id)
        {
          if (_context.Customers == null)
          {
              return NotFound();
          }
            var customerData = await _context.Customers.FindAsync(id);

            if (customerData == null)
            {
                return NotFound();
            }

            return customerData;
        }

        // PUT: api/CustomerDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerData(int id, CustomerData customerData)
        {
            if (id != customerData.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CustomerDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerData>> PostCustomerData(CustomerData customerData)
        {
          if (_context.Customers == null)
          {
              return Problem("Entity set 'DataContext.Customers'  is null.");
          }
            _context.Customers.Add(customerData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerData", new { id = customerData.Id }, customerData);
        }

        // DELETE: api/CustomerDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerData(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customerData = await _context.Customers.FindAsync(id);
            if (customerData == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerDataExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
