using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Server.Data;
using Demo.Shared.Entidades;
using Demo.Shared.DTOs;
using Demo.Server.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenerosController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost("insertarMasivo")]
        public async Task<ActionResult> CargaMasiva()
        {
            try
            {
                List<Genero> generos = new List<Genero>();

                for (int i = 0; i < 10000; i++)
                {
                    generos.Add(new Genero { Estado = true, Nombre = $"Genero {i}" });
                }

                await _context.AddRangeAsync(generos);
                await _context.SaveChangesAsync();

                return Ok($"Se inserto {generos.Count} a la base de datos.");
            }
            catch (Exception ex)
            {

                return BadRequest($"cocurrio un erroro  {ex.Message}");
            }
        }


        // GET: api/Generos
        [HttpGet]
        //[Authorize]     //SOLO USUARIOS AUTENTICADOS
        [Authorize(Roles = "superusuario")] //SOLO LOS USURIOS QUE SON SUPERUSUARIO PUEDEN ACCEDER A ESTE RECURSO
        public async Task<ActionResult<IEnumerable<Genero>>> GetGenero([FromQuery] PaginacionDTO paginacion)
        {
            //return await _context.Genero.ToListAsync();

            var queryable = _context.Genero.AsQueryable();
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadRegistros);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        // GET: api/Generos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genero>> GetGenero(int id)
        {
            var genero = await _context.Genero.FindAsync(id);

            if (genero == null)
            {
                return NotFound("No encontrado");
            }

            return genero;
        }

        // PUT: api/Generos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenero(int id, Genero genero)
        {
            if (id != genero.Id)
            {
                return BadRequest("La solucitud no contine Id");
            }

            _context.Entry(genero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return NoContent();
        }

        // POST: api/Generos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
        {
            _context.Genero.Add(genero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenero", new { id = genero.Id }, genero);
        }

        // DELETE: api/Generos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenero(int id)
        {
            var genero = await _context.Genero.FindAsync(id);
            if (genero == null)
            {
                return NotFound("El registro con el id no encontrado");
            }

            _context.Genero.Remove(genero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //private bool GeneroExists(int id)
        //{
        //    return _context.Genero.Any(e => e.Id == id);
        //}
    }
}
