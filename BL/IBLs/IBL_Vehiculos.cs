using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.IBLs
{
    public interface IBL_Vehiculos
    {
        List<Vehiculo> GetVehiculos();
        Vehiculo GetVehiculo(string matricula);
        void AddVehiculo(Vehiculo vehiculo);
        void DeleteVehiculo(string matricula);
        void UpdateVehiculo(Vehiculo vehiculo);
    }
}
