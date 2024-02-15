using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Shared.Entidades
{
    public class Pelicula
    {
        public int Id { get; set; }
        [Column(TypeName ="Varchar(50)")]
        public string Titulo { get; set; }
        public string Resumen { get; set; }
        public bool EnCartelera { get; set; }
        public string Trailer { get; set; }
        public DateTime Lanzamiento { get; set; }
        public string Poster { get; set; }
    }
}
