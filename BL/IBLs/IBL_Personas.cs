using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace BL.IBLs
{
    public interface IBL_Personas
    {
        List<Persona> GetPersonas();
        Persona GetPersona(string cedula);
        void AddPersona(Persona persona);
        void DeletePersona(string cedula);
        void UpdatePersona(Persona persona);
    }
}
