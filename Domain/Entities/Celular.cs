using Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Celular
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }


        public void Validar()
        {
            if (string.IsNullOrEmpty(Marca))
                throw new BusinessException("La marca del celular no puede estar vacía.");
            if (string.IsNullOrEmpty(Modelo))
                throw new BusinessException("El modelo del celular no puede estar vacío.");
            if (Año < 2000 || Año > DateTime.Now.Year)
                throw new BusinessException("El año del celular no es válido.");
        }
    }
}
