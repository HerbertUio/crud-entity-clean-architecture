﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
    }
}
