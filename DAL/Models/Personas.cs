using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Personas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]   
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public int Edad { get; set; } = 0;

        public virtual ICollection<Vehiculos> Vehiculos { get; set; }

        public Personas getEntity()
        {
            return new Personas
            {
                Id = this.Id,
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Documento = this.Documento,
                Edad = this.Edad
            };
        }

        public static Personas FromEntity (Personas entity)
        {
            return new Personas
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Apellido = entity.Apellido,
                Documento = entity.Documento,
                Edad = entity.Edad
            };
        }

        public string GetStringConVehiculo(DbContext context)
        {
            var personaConVehiculos = context.Set<Personas>()
                                             .Include(p => p.Vehiculos)
                                             .FirstOrDefault(p => p.Id == this.Id);

            if (personaConVehiculos == null)
            {
                return "Persona no encontrada.";
            }

            var infoPersona = $"Id: {personaConVehiculos.Id}, Nombre: {personaConVehiculos.Nombre}, Apellido: {personaConVehiculos.Apellido}, Documento: {personaConVehiculos.Documento}, Edad: {personaConVehiculos.Edad}";

            var infoVehiculos = new StringBuilder();
            foreach (var vehiculo in personaConVehiculos.Vehiculos)
            {
                infoVehiculos.AppendLine($"Vehiculo Id: {vehiculo.Id}, Marca: {vehiculo.Marca}, Modelo: {vehiculo.Modelo}, Matricula: {vehiculo.Matricula}");
            }

            return $"{infoPersona}\nVehiculos:\n{infoVehiculos}";
        }

        public string GetString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Apellido: {Apellido}, Documento: {Documento}, Edad: {Edad}";
        }

    }
}
