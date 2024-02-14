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
        public VehicleType? VehicleType { get; set; }
        VehicleType IParkingSlot.VehicleType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Park(string vehicleNumber, VehicleType vehicleType)
        {
            IsOccupied = true;
            VehicleNumber = vehicleNumber;
            VehicleType = vehicleType;
        }

        public void Unpark()
        {
            IsOccupied = false;
            VehicleNumber = null;
            VehicleType = null;
        }
    }
}
