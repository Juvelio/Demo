﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Shared.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistros { get; set; } = 10;
    }
}
