using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL.IDALs;

namespace DAL.DALs
{
    public class DAL_Vehiculo_EF : IDAL_Vehiculo
    {
        private DBContext _context;

        public DAL_Vehiculo_EF(DBContext dBContext)
        {
            _context = dBContext;
        }

        public void AddVehiculo(Vehiculos vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
        }

        public Vehiculos GetVehiculo(string matricula)
        {
            return _context.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
        }

        public void DeleteVehiculo(string matricula)
        {
            Vehiculos vehiculo = GetVehiculo(matricula);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                _context.SaveChanges();
            }
        }

        public List<Vehiculos> GetVehiculos()
        {
            return _context.Vehiculos.ToList();
        }

        public void UpdateVehiculo(Vehiculos vehiculo)
        {
            Vehiculos vehiculoToUpdate = GetVehiculo(vehiculo.Matricula);
            if (vehiculoToUpdate != null)
            {
                vehiculoToUpdate.Marca = vehiculo.Marca;
                vehiculoToUpdate.Modelo = vehiculo.Modelo;
                vehiculoToUpdate.Matricula = vehiculo.Matricula;
                _context.SaveChanges();
            }
        }


    }
}
