using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class ParkingTicketService
    {
        private string VehicleNumber;
        private string VehicleType;
        private int SlotNumber;
        private DateTime InTime;
        private DateTime OutTime;
        public ParkingTicketService(string vehicleNumber, string vehicleType, int slotNumber,DateTime inTime,DateTime outTime) 
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
