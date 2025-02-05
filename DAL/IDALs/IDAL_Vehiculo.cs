﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Shared;

namespace DAL.IDALs
{
    public interface IDAL_Vehiculo
    {
        List<Vehiculo> GetVehiculos();
        Vehiculo GetVehiculo(string matricula);
        void AddVehiculo(Vehiculo vehiculo);
        void DeleteVehiculo(string matricula);
        void UpdateVehiculo(Vehiculo vehiculo);
    }
}
