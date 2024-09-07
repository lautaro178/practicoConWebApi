using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using DAL.IDALs;
using DAL.Models;

namespace DAL.DALs
{
    public class DAL_Vehiculo_EF : IDAL_Vehiculo
    {
        private DBContext _context;

        public DAL_Vehiculo_EF(DBContext dBContext)
        {
            _context = dBContext;
        }

        public void AddVehiculo(Vehiculo vehiculo)
        {
            var vehiculoEntity = Vehiculos.FromEntity(vehiculo);
            _context.Vehiculos.Add(vehiculoEntity);
            _context.SaveChanges();
        }

        public Vehiculo GetVehiculo(string matricula)
        {
            var vehiculoEntity = _context.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
            if (vehiculoEntity != null)
            {
                return vehiculoEntity.getEntity();
            }
            else
            {
                return null;
            }
        }

        public void DeleteVehiculo(string matricula)
        {
            var vehiculoEntity = _context.Vehiculos.FirstOrDefault(v => v.Matricula == matricula);
            if (vehiculoEntity != null)
            {
                _context.Vehiculos.Remove(vehiculoEntity);
                _context.SaveChanges();
            }
        }

        public List<Vehiculo> GetVehiculos()
        {
            return _context.Vehiculos.Select(v => new Vehiculo { Id = v.Id, Marca = v.Marca, Modelo = v.Modelo, Matricula = v.Matricula }).ToList();
        }

        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            var vehiculoEntity = _context.Vehiculos.FirstOrDefault(v => v.Matricula == vehiculo.Matricula);
            if (vehiculoEntity != null)
            {
                vehiculoEntity = Vehiculos.FromEntity(vehiculo);
                _context.SaveChanges();
            }
        }


    }
}
