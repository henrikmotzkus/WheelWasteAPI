using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WheelWasteAPI.Model;

namespace WheelWasteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WheelWasteCollectionDatumsController : ControllerBase
    {
        private readonly hackthon1Context _context;

        public WheelWasteCollectionDatumsController(hackthon1Context context)
        {
            _context = context;
        }

        // GET: api/WheelWasteCollectionDatums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WheelWasteCollectionDatum>>> GetWheelWasteCollectionData()
        {
            return await _context.WheelWasteCollectionData.ToListAsync();
        }

        // GET: api/WheelWasteCollectionDatums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WheelWasteCollectionDatum>> GetWheelWasteCollectionDatum(int id)
        {
            var wheelWasteCollectionDatum = await _context.WheelWasteCollectionData.FindAsync(id);

            if (wheelWasteCollectionDatum == null)
            {
                return NotFound();
            }

            return wheelWasteCollectionDatum;
        }

        // PUT: api/WheelWasteCollectionDatums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWheelWasteCollectionDatum(int id, WheelWasteCollectionDatum wheelWasteCollectionDatum)
        {
            if (id != wheelWasteCollectionDatum.Id)
            {
                return BadRequest();
            }

            _context.Entry(wheelWasteCollectionDatum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WheelWasteCollectionDatumExists(id))
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

        // POST: api/WheelWasteCollectionDatums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WheelWasteCollectionDatum>> PostWheelWasteCollectionDatum(WheelWasteCollectionDatum wheelWasteCollectionDatum)
        {
            _context.WheelWasteCollectionData.Add(wheelWasteCollectionDatum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWheelWasteCollectionDatum", new { id = wheelWasteCollectionDatum.Id }, wheelWasteCollectionDatum);
        }

        // DELETE: api/WheelWasteCollectionDatums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWheelWasteCollectionDatum(int id)
        {
            var wheelWasteCollectionDatum = await _context.WheelWasteCollectionData.FindAsync(id);
            if (wheelWasteCollectionDatum == null)
            {
                return NotFound();
            }

            _context.WheelWasteCollectionData.Remove(wheelWasteCollectionDatum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WheelWasteCollectionDatumExists(int id)
        {
            return _context.WheelWasteCollectionData.Any(e => e.Id == id);
        }
    }
}
