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
        public ParkingTicketService(ParkingTicket ticketDetails) 
        {
            VehicleNumber = ticketDetails.VehicleNumber;
            VehicleType = ticketDetails.VehicleType;
            SlotNumber = ticketDetails.SlotNumber;
            InTime = ticketDetails.InTime;
            OutTime = ticketDetails.OutTime;
          
        }
        public void DisplayTicket()
        {
           
            Console.WriteLine(Messages.Dash);
            Console.WriteLine($"| {Messages.VehicleNumber} : {VehicleNumber}");
            Console.WriteLine($"| {Messages.VehicleType} : {VehicleType}");
            Console.WriteLine($"| {Messages.SlotNumber} : {SlotNumber}");
            Console.WriteLine($"| {Messages.InTime}  : {InTime}");
            Console.WriteLine($"| {Messages.OutTime}  : {OutTime}");
            Console.WriteLine($"{Messages.Dash}\n");
        }
        
    }
}
