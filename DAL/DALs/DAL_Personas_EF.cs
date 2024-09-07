using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.IDALs;
using Shared;

namespace DAL.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContext _context;

        public DAL_Personas_EF(DBContext dBContext)
        {
            _context = dBContext;
        }

        public void AddPersona(Persona persona)
        {
            var personaEntity = Personas.FromEntity(persona);
            _context.Personas.Add(personaEntity);
            _context.SaveChanges();
        }

        public Persona GetPersona(string cedula)
        {
            var PersonaEntity = _context.Personas.FirstOrDefault(p => p.Documento == cedula);
            if (PersonaEntity != null)
            {
                return PersonaEntity.getEntity();
            }
            else
            {
                return null;
            }
        }

        public List<Persona> GetPersonas()
        {
            return _context.Personas.Select(p => new Persona { Documento = p.Documento, Nombre = p.Nombre, Apellido = p.Apellido, Edad = p.Edad }).ToList();
        }

        public void DeletePersona(string id)
        {
            var personaEntity = _context.Personas.FirstOrDefault(p => p.Documento == id);
            if (personaEntity != null)
            {
                _context.Personas.Remove(personaEntity);
                _context.SaveChanges();
            }
        }

        public void UpdatePersona(Persona persona)
        {
            var personaEntity = _context.Personas.FirstOrDefault(p => p.Documento == persona.Documento);
            if (personaEntity != null)
            {
                personaEntity = Personas.FromEntity(persona);
                _context.SaveChanges();
            }
        }
    }
}
