using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.IBLs;
using DAL;
using DAL.DALs;
using DAL.IDALs;
using Shared;

namespace BL.BLs
{
    public class BL_Personas : IBL_Personas
    {
        private readonly IDAL_Personas dal;

        public BL_Personas(IDAL_Personas _dal)
        {
            dal = _dal;
        }

        public void AddPersona(Persona persona)
        {
            dal.AddPersona(persona);
        }

        public void DeletePersona(string ceula)
        {
            dal.DeletePersona(ceula);
        }

        public Persona GetPersona(string ci)
        {
            return dal.GetPersona(ci);
        }

        public List<Persona> GetPersonas()
        {
            return dal.GetPersonas();
        }

        public void UpdatePersona(Persona persona)
        {
            dal.UpdatePersona(persona);
        }
    }
}