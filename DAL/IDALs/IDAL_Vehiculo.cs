using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.IDALs
{
    public interface IDAL_Vehiculo
    {
        List<Vehiculos> GetVehiculos();
        Vehiculos GetVehiculo(string matricula);
        void AddVehiculo(Vehiculos vehiculo);
        void DeleteVehiculo(string matricula);
        void UpdateVehiculo(Vehiculos vehiculo);
    }
}
