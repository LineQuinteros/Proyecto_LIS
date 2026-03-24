using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LIS.API.Data;
using Modelos_LIS;

namespace LIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly LISAPIContext _context;

        public OrdenesController(LISAPIContext context)
        {
            _context = context;
        }

        // GET: api/Ordenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ordenes>>> GetOrdenes()
        {
            return await _context.Ordenes.ToListAsync();
        }

        // GET: api/Ordenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> GetOrdenes(int id)
        {
            var ordenes = await _context.Ordenes.FindAsync(id);

            if (ordenes == null)
            {
                return NotFound();
            }

            return ordenes;
        }

        // PUT: api/Ordenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenes(int id, Ordenes ordenes)
        {
            if (id != ordenes.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesExists(id))
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

        // POST: api/Ordenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ordenes>> PostOrdenes(Ordenes ordenes)
        {
            _context.Ordenes.Add(ordenes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenes", new { id = ordenes.Id }, ordenes);
        }

        // DELETE: api/Ordenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrdenes(int id)
        {
            var ordenes = await _context.Ordenes.FindAsync(id);
            if (ordenes == null)
            {
                return NotFound();
            }

            _context.Ordenes.Remove(ordenes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrdenesExists(int id)
        {
            return _context.Ordenes.Any(e => e.Id == id);
        }
    }
}
