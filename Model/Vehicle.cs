using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ParkingLotSimulation
{
   

    public class Vehicle : IVehicle
    {
        public string VehicleNumber { get; }

        protected Vehicle(string vehicleNumber)
        {
            VehicleNumber = vehicleNumber;
        }
    }
}
