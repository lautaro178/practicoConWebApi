using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DAL.Models
{
    public class Vehiculos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Matricula { get; set; } = string.Empty;

        public Personas? Persona { get; set; }

        public Vehiculo getEntity()
        {
            return new Vehiculo
            {
                Id = this.Id,
                Marca = this.Marca,
                Modelo = this.Modelo,
                Matricula = this.Matricula
            };
        }

        public static Vehiculos FromEntity(Vehiculo entity)
        {
            return new Vehiculos
            {
                Id = entity.Id,
                Marca = entity.Marca,
                Modelo = entity.Modelo,
                Matricula = entity.Matricula
            };
        }

        public string GetString()
        {
            return $"Id: {Id}, Marca: {Marca}, Modelo: {Modelo}, Matricula: {Matricula}";
        }
    }
}
