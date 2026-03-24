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
    public class ResultadosController : ControllerBase
    {
        private readonly LISAPIContext _context;

        public ResultadosController(LISAPIContext context)
        {
            _context = context;
        }

        // GET: api/Resultados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resultados>>> GetResultados()
        {
            var resultados = await _context.Resultados.Include(r => r.Orden).ThenInclude(r => r.Paciente).Include(r => r.Examen).ToListAsync();
            return resultados;
        }

        // GET: api/Resultados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resultados>> GetResultados(int id)
        {
            var resultados = await _context.Resultados.FindAsync(id);

            if (resultados == null)
            {
                return NotFound();
            }

            return resultados;
        }

        // PUT: api/Resultados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResultados(int id, Resultados resultados)
        {
            if (id != resultados.Id)
            {
                return BadRequest();
            }

            _context.Entry(resultados).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResultadosExists(id))
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

        // POST: api/Resultados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resultados>> PostResultados(Resultados resultados)
        {
            _context.Resultados.Add(resultados);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResultados", new { id = resultados.Id }, resultados);
        }

        // DELETE: api/Resultados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResultados(int id)
        {
            var resultados = await _context.Resultados.FindAsync(id);
            if (resultados == null)
            {
                return NotFound();
            }

            _context.Resultados.Remove(resultados);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResultadosExists(int id)
        {
            return _context.Resultados.Any(e => e.Id == id);
        }
    }
}
