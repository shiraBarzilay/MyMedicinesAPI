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
    public class UserMedicinesTblsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public UserMedicinesTblsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/UserMedicinesTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMedicinesTbl>>> GetUserMedicinesTbls()
        {
            return await _context.UserMedicinesTbls.ToListAsync();
        }

        // GET: api/UserMedicinesTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMedicinesTbl>> GetUserMedicinesTbl(int id)
        {
            var userMedicinesTbl = await _context.UserMedicinesTbls.FindAsync(id);

            if (userMedicinesTbl == null)
            {
                return NotFound();
            }

            return userMedicinesTbl;
        }

        // PUT: api/UserMedicinesTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMedicinesTbl(int id, UserMedicinesTbl userMedicinesTbl)
        {
            if (id != userMedicinesTbl.UserMedicineId)
            {
                return BadRequest();
            }

            _context.Entry(userMedicinesTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMedicinesTblExists(id))
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

        // POST: api/UserMedicinesTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserMedicinesTbl>> PostUserMedicinesTbl(UserMedicinesTbl userMedicinesTbl)
        {
            _context.UserMedicinesTbls.Add(userMedicinesTbl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UserMedicinesTblExists(userMedicinesTbl.UserMedicineId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUserMedicinesTbl", new { id = userMedicinesTbl.UserMedicineId }, userMedicinesTbl);
        }

        // DELETE: api/UserMedicinesTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserMedicinesTbl(int id)
        {
            var userMedicinesTbl = await _context.UserMedicinesTbls.FindAsync(id);
            if (userMedicinesTbl == null)
            {
                return NotFound();
            }

            _context.UserMedicinesTbls.Remove(userMedicinesTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserMedicinesTblExists(int id)
        {
            return _context.UserMedicinesTbls.Any(e => e.UserMedicineId == id);
        }
    }
}
