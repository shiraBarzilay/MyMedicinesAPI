using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.GeneratedModels;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersTblsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public UsersTblsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/UsersTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersTbl>>> GetUsersTbls()
        {
            return await _context.UsersTbls.ToListAsync();
        }

        // GET: api/UsersTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersTbl>> GetUsersTbl(int id)
        {
            var usersTbl = await _context.UsersTbls.FindAsync(id);

            if (usersTbl == null)
            {
                return NotFound();
            }

            return usersTbl;
        }

        // PUT: api/UsersTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersTbl(int id, UsersTbl usersTbl)
        {
            if (id != usersTbl.UserId)
            {
                return BadRequest();
            }

            _context.Entry(usersTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersTblExists(id))
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

        // POST: api/UsersTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersTbl>> PostUsersTbl(UsersTbl usersTbl)
        {
            _context.UsersTbls.Add(usersTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersTbl", new { id = usersTbl.UserId }, usersTbl);
        }

        // DELETE: api/UsersTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersTbl(int id)
        {
            var usersTbl = await _context.UsersTbls.FindAsync(id);
            if (usersTbl == null)
            {
                return NotFound();
            }

            _context.UsersTbls.Remove(usersTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersTblExists(int id)
        {
            return _context.UsersTbls.Any(e => e.UserId == id);
        }
    }
}

