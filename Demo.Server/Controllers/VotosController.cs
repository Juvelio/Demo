using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Server.Data;
using Demo.Shared.Entidades;

namespace Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VotosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public VotosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Votos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VotoPelicula>>> GetVotosPeliculas()
        {
            return await _context.VotosPeliculas.ToListAsync();
        }

        // GET: api/Votos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VotoPelicula>> GetVotoPelicula(int id)
        {
            var votoPelicula = await _context.VotosPeliculas.FindAsync(id);

            if (votoPelicula == null)
            {
                return NotFound();
            }

            return votoPelicula;
        }

        // PUT: api/Votos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVotoPelicula(int id, VotoPelicula votoPelicula)
        {
            if (id != votoPelicula.Id)
            {
                return BadRequest();
            }

            _context.Entry(votoPelicula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VotoPeliculaExists(id))
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

        // POST: api/Votos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VotoPelicula>> PostVotoPelicula(VotoPelicula votoPelicula)
        {
            _context.VotosPeliculas.Add(votoPelicula);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVotoPelicula", new { id = votoPelicula.Id }, votoPelicula);
        }

        // DELETE: api/Votos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVotoPelicula(int id)
        {
            var votoPelicula = await _context.VotosPeliculas.FindAsync(id);
            if (votoPelicula == null)
            {
                return NotFound();
            }

            _context.VotosPeliculas.Remove(votoPelicula);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VotoPeliculaExists(int id)
        {
            return _context.VotosPeliculas.Any(e => e.Id == id);
        }
    }
}
