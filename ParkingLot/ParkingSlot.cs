using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public interface IParkingSlot
    {
        bool IsOccupied { get; }
        string VehicleNumber { get; set; }
        void Park(string vehicleNumber);
        void Unpark();
    }

   
    public class ParkingSlot : IParkingSlot
    {
        public bool IsOccupied { get; private set; }
        public string VehicleNumber { get; set; }

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
