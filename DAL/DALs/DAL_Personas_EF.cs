using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.IDALs;

namespace DAL.DALs
{
    public class DAL_Personas_EF : IDAL_Personas
    {
        private DBContext _context;

        public DAL_Personas_EF(DBContext dBContext)
        {
            _context = dBContext;
        }

        public void AddPersona(Personas persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        public Personas GetPersona(string cedula)
        {
            return _context.Personas.FirstOrDefault(p => p.Documento == cedula);
        }

        public List<Personas> GetPersonas()
        {
            return _context.Personas.ToList();
        }

        public void DeletePersona(string id)
        {
            Personas persona = GetPersona(id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }

        public void UpdatePersona(Personas persona)
        {
            Personas personaToUpdate = GetPersona(persona.Documento);
            if (personaToUpdate != null)
            {
                personaToUpdate.Nombre = persona.Nombre;
                personaToUpdate.Apellido = persona.Apellido;
                personaToUpdate.Documento = persona.Documento;
                personaToUpdate.Edad = persona.Edad;
                _context.SaveChanges();
            }
        }
    }
}
