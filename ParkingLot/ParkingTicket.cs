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

        public void DisplayTicket()
        {
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"| Vehicle Number : {VehicleNumber}");
            Console.WriteLine($"| Vehicle Type : {VehicleType}");
            Console.WriteLine($"| Slot Number : {SlotNumber}");
            Console.WriteLine($"| InTime : {InTime}");
            Console.WriteLine($"| OutTime : {OutTime}");
            Console.WriteLine("-------------------------------------\n");
        }
    }
}
