using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;

        public Persona Persona { get; set; }

        public string GetString()
        {
            return $"Id: {Id}, Marca: {Marca}, Modelo: {Modelo}, Matricula: {Matricula}";
        }
    }
}
