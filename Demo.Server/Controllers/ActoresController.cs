using Demo.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Demo.Shared.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Demo.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ActorRepository _repository;

        public ActoresController(ApplicationDbContext context, ActorRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        [HttpGet]
        public async Task<List<Actor>> Get()
        {
            List<Actor> actores = await _context.Actor.ToListAsync();
            return actores;
        }

        [HttpGet("procedimiento")]
        public async Task<List<Actor>> GetProcedimeintoAlmacenado()
        {
            List<Actor> actores = _repository.ListarActores();
            return actores;
        }



        [HttpPost]
        public async Task<Actor> Post(Actor actor)
        {
            _context.Actor.Add(actor);
            await _context.SaveChangesAsync();

            return actor;
        }


        [HttpPost("procedimiento")]
        public async Task<string> PostProcedimeinto(Actor actor)
        {
            string respuesta = await _repository.InsertarActor(actor);
            return respuesta;
        }

        [HttpPost("Modificar")]
        public async Task<string> PostModificar(Actor actor)
        {
            string respuesta = await _repository.ModificarActor(actor);
            return respuesta;
        }


        [HttpPost("Eliminar")]
        public async Task<string> PostEliminar(Actor actor)
        {
            string respuesta = await _repository.EliminarActor(actor);
            return respuesta;
        }


    }
}
