using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ParkingLotSimulation
{
   

   
    public class ParkingSlot : IParkingSlot
    {
        public bool IsOccupied { get; private set; }
        public string? VehicleNumber { get; set; }

        public void Park(string vehicleNumber)
        {
            IsOccupied = true;
            VehicleNumber = vehicleNumber;
        }

        public void Unpark()
        {
            IsOccupied = false;
            VehicleNumber = null;
        }
    }
}
