using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LIS.API.Data;
using Modelos_LIS;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Blazor;

namespace LIS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly LISAPIContext _context;

        public MedicosController(LISAPIContext context)
        {
            _context = context;
        }

        // GET: api/Medicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medicos>>> GetMedicos()
        {
            var medicos = await _context.Medicos.Include(m => m.Especialidad).ToListAsync();
            return medicos;


            
        }

        // GET: api/Medicos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medicos>> GetMedicos(int id)
        {
            var medicos = await _context.Medicos.FindAsync(id);

            if (medicos == null)
            {
                return NotFound();
            }

            return medicos;
        }

        

        // PUT: api/Medicos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicos(int id, Medicos medicos)
        {
            if (id != medicos.Id)
            {
                return BadRequest();
            }

            _context.Entry(medicos).State = EntityState.Modified;
            medicos.med_password = BCrypt.Net.BCrypt.HashPassword(medicos.med_password);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicosExists(id))
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

        // POST: api/Medicos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicos>> PostMedicos(Medicos medicos)
        {
            medicos.med_password = BCrypt.Net.BCrypt.HashPassword(medicos.med_password);

            _context.Medicos.Add(medicos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedicos", new { id = medicos.Id }, medicos);
        }

        // DELETE: api/Medicos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicos(int id)
        {
            var medicos = await _context.Medicos.FindAsync(id);
            if (medicos == null)
            {
                return NotFound();
            }

            _context.Medicos.Remove(medicos);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MedicosExists(int id)
        {
            return _context.Medicos.Any(e => e.Id == id);
        }
    }
}
