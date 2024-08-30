using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.IDALs
{
    public interface IDAL_Personas
    {
        List<Personas> GetPersonas();
        Personas GetPersona(string cedula);
        void AddPersona(Personas persona);
        void DeletePersona(string cedula);
        void UpdatePersona(Personas persona);
    }
}
