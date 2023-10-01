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
    public class UserDatasController : ControllerBase
    {
        private readonly UserDataContext _context;

        public UserDatasController(UserDataContext context)
        {
            _context = context;
        }

        // GET: api/UserDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserData>>> GetUsers()
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserData>> GetUserData(int id)
        {
          if (_context.Users == null)
          {
              return NotFound();
          }
            var userData = await _context.Users.FindAsync(id);

            if (userData == null)
            {
                return NotFound();
            }

            return userData;
        }

        // PUT: api/UserDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserData(int id, UserData userData)
        {
            if (id != userData.UserId)
            {
                return BadRequest();
            }

            _context.Entry(userData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserDataExists(id))
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

        // POST: api/UserDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<List<UserData>>> PostUserData(UserData userData)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'UserDataContext.Users' is null.");
            }
            _context.Users.Add(userData);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        // DELETE: api/UserDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserData(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var userData = await _context.Users.FindAsync(id);
            if (userData == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserDataExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
