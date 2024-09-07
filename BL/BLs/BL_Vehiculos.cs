using System;
using System.Collections.Generic;
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
    public class BL_Vehiculos : IBL_Vehiculos
    {
        private readonly IDAL_Vehiculo dal;

        public BL_Vehiculos(IDAL_Vehiculo _dal)
        {
            dal = _dal;
        }

        public void AddVehiculo(Vehiculo vehiculo)
        {
            dal.AddVehiculo(vehiculo);
        }

        public void DeleteVehiculo(string matricula)
        {
            dal.DeleteVehiculo(matricula);
        }

        public Vehiculo GetVehiculo(string matricula)
        {
            return dal.GetVehiculo(matricula);
        }

        public List<Vehiculo> GetVehiculos()
        {
            return dal.GetVehiculos();
        }

        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            dal.UpdateVehiculo(vehiculo);
        }
    }
}