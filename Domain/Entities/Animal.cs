using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }

        // Método de validación
        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new BusinessException("El nombre del animal no puede estar vacío.");
            if (string.IsNullOrEmpty(Especie))
                throw new BusinessException("La especie del animal no puede estar vacía.");
            if (Edad < 0)
                throw new BusinessException("La edad no puede ser negativa.");
        }
    }
}
