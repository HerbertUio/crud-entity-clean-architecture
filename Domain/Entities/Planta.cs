using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Planta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }
        public bool EsPerenne { get; set; }

        // Método de validación
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new BusinessException("El nombre de la planta no puede estar vacío.");
            if (string.IsNullOrEmpty(Tipo))
                throw new BusinessException("El tipo de planta no puede estar vacío.");
        }
    }
}
