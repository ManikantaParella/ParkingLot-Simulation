using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public interface IVehicle
    {
        string VehicleNumber { get; }
    }

    public class Vehicle : IVehicle
    {
        public string VehicleNumber { get; }

        protected Vehicle(string vehicleNumber)
        {
            VehicleNumber = vehicleNumber;
        }
    }
}
