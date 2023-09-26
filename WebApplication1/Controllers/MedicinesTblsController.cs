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
    public class MedicinesTblsController : ControllerBase
    {
        private readonly MyDBContext _context;
        private readonly EmailManager _emailManager;

        public MedicinesTblsController(MyDBContext context, EmailManager emailManager)
        {
            _context = context;
            _emailManager = emailManager;
        }
        [Route("send")]
        public ActionResult EmailSend()
        {
            _emailManager.SendEmail("m0548462581@gmail.com", "מרים");
            return Ok();
        }

        // GET: api/MedicinesTbls
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MedicinesTbl>>> GetMedicinesTbls()
        {
            return await _context.MedicinesTbls.ToListAsync();
        }

        // GET: api/MedicinesTbls/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MedicinesTbl>> GetMedicinesTbl(int id)
        {
            var medicinesTbl = await _context.MedicinesTbls.FindAsync(id);

            if (medicinesTbl == null)
            {
                return NotFound();
            }

            return medicinesTbl;
        }

        // PUT: api/MedicinesTbls/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicinesTbl(int id, MedicinesTbl medicinesTbl)
        {
            if (id != medicinesTbl.MedicineId)
            {
                return BadRequest();
            }

            _context.Entry(medicinesTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicinesTblExists(id))
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

        // POST: api/MedicinesTbls
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MedicinesTbl>> PostMedicinesTbl(MedicinesTbl medicinesTbl)
        {
            _context.MedicinesTbls.Add(medicinesTbl);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MedicinesTblExists(medicinesTbl.MedicineId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMedicinesTbl", new { id = medicinesTbl.MedicineId }, medicinesTbl);
        }

        // DELETE: api/MedicinesTbls/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicinesTbl(int id)
        {
            var medicinesTbl = await _context.MedicinesTbls.FindAsync(id);
            if (medicinesTbl == null)
            {
                return NotFound();
            }

            _context.MedicinesTbls.Remove(medicinesTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicinesTblExists(int id)
        {
            return _context.MedicinesTbls.Any(e => e.MedicineId == id);
        }
    }
}
