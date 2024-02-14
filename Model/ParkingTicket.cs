using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class ParkingTicket
    {
        public string VehicleNumber { get; set; }
        public string VehicleType { get; set; }
        public int SlotNumber { get; set; }
        public DateTime InTime { get; set; }
        public DateTime OutTime { get; set; }

        public ParkingTicket(string vehicleNumber, string vehicleType, int slotNumber, DateTime inTime, DateTime outTime)
        {
            VehicleNumber = vehicleNumber;
            VehicleType = vehicleType;
            SlotNumber = slotNumber;
            InTime = inTime;
            OutTime = outTime;
        }

    }
}
