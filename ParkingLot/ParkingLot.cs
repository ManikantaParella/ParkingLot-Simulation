using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class ParkingLot
    {
        private int twoWheelerCapacity;
        private int fourWheelerCapacity;
        private int heavyVehicleCapacity;
        private string? vehicleTypeName;
        private List<IParkingSlot> twoWheelerSlots;
        private List<IParkingSlot> fourWheelerSlots;
        private List<IParkingSlot> heavyVehicleSlots;
        private Dictionary<string, DateTime> vehicleParkingTimes;

        public ParkingLot(int numTwoWheelerSlots, int numFourWheelerSlots, int numHeavyVehicleSlots)
        {
            twoWheelerCapacity = numTwoWheelerSlots;
            fourWheelerCapacity = numFourWheelerSlots;
            heavyVehicleCapacity = numHeavyVehicleSlots;
            twoWheelerSlots = new List<IParkingSlot>();
            fourWheelerSlots = new List<IParkingSlot>();
            heavyVehicleSlots = new List<IParkingSlot>();
            vehicleParkingTimes = new Dictionary<string, DateTime>();

            InitializeParkingSlots();
        }

        private void InitializeParkingSlots()
        {
            for (int i = 0; i < twoWheelerCapacity; i++)
            {   
                twoWheelerSlots.Add(new ParkingSlot());
            }
            for (int i = 0; i < fourWheelerCapacity; i++)
            {
                fourWheelerSlots.Add(new ParkingSlot());
            }
            for (int i = 0; i < heavyVehicleCapacity; i++)
            {
                heavyVehicleSlots.Add(new ParkingSlot());
            }
        }

        public void CheckOccupancyDetails()
        {
            Console.WriteLine("Current occupancy details:");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"2-wheeler slots: {GetOccupiedSlotsCount(twoWheelerSlots)} occupied, {twoWheelerCapacity - GetOccupiedSlotsCount(twoWheelerSlots)} available");
            Console.WriteLine($"4-wheeler slots: {GetOccupiedSlotsCount(fourWheelerSlots)} occupied, {fourWheelerCapacity - GetOccupiedSlotsCount(fourWheelerSlots)} available");
            Console.WriteLine($"Heavy vehicle slots: {GetOccupiedSlotsCount(heavyVehicleSlots)} occupied, {heavyVehicleCapacity - GetOccupiedSlotsCount(heavyVehicleSlots)} available");
            Console.WriteLine("-------------------------------------\n");
        }

        private int GetOccupiedSlotsCount(List<IParkingSlot> slots)
        {
            return slots.Count(slot => slot.IsOccupied);
        }

        private void ParkVehicle(string vehicleNumber, DateTime inTime, List<IParkingSlot> slots)
        {
            IParkingSlot slot = slots.FirstOrDefault(s => !s.IsOccupied);
            if (slot != null)
            {
                slot.Park(vehicleNumber);
                vehicleParkingTimes.Add(vehicleNumber, inTime);
                ParkingTicketService ticket = new ParkingTicketService(vehicleNumber, vehicleTypeName, slots.IndexOf(slot) + 1, DateTime.Now, DateTime.MinValue);
                ticket.DisplayTicket();
                Console.WriteLine($"Vehicle {vehicleNumber} parked at slot {slots.IndexOf(slot) + 1}");
            }
            else
            {
                Console.WriteLine("No available slots.");
            }
        }

        private void UnparkVehicle(string vehicleNumber, List<IParkingSlot> slots)
        {
            IParkingSlot slot = slots.FirstOrDefault(s => s.IsOccupied && ((ParkingSlot)s).VehicleNumber == vehicleNumber);
            DateTime inTime = vehicleParkingTimes[vehicleNumber];
            vehicleParkingTimes.Remove(vehicleNumber);
            if (slot != null)
            {
                slot.Unpark();
                ParkingTicketService ticket = new ParkingTicketService(vehicleNumber, vehicleTypeName, slots.IndexOf(slot) + 1, inTime, DateTime.Now);
                ticket.DisplayTicket();
                Console.WriteLine($"Vehicle {vehicleNumber} unparked from slot {slots.IndexOf(slot) + 1}");
            }
            else
            {
                Console.WriteLine($"Vehicle {vehicleNumber} not found.");
            }
        }

        public void ParkTwoWheeler(string vehicleNumber, DateTime inTime)
        {
            ParkVehicle(vehicleNumber, inTime, twoWheelerSlots);
        }

        public void ParkFourWheeler(string vehicleNumber, DateTime inTime)
        {
            ParkVehicle(vehicleNumber, inTime, fourWheelerSlots);
        }

        public void ParkHeavyVehicle(string vehicleNumber, DateTime inTime)
        {
            ParkVehicle(vehicleNumber, inTime, heavyVehicleSlots);
        }

        public void UnparkTwoWheeler(string vehicleNumber)
        {
            UnparkVehicle(vehicleNumber, twoWheelerSlots);
        }

        public void UnparkFourWheeler(string vehicleNumber)
        {
            UnparkVehicle(vehicleNumber, fourWheelerSlots);
        }

        public void UnparkHeavyVehicle(string vehicleNumber)
        {
            UnparkVehicle(vehicleNumber, heavyVehicleSlots);
        }

        public ParkingTicket? ParkVehicle(IVehicle vehicle)
        {
            Console.WriteLine($"Enter Vehicle Number: {vehicle.VehicleNumber}");
            Console.WriteLine("Enter Vehicle Type (1.TwoWheeler/ 2.FourWheeler/ 3.HeavyVehicle):");
            int vehicleType;
            while (!int.TryParse(Console.ReadLine(), out vehicleType) || vehicleType < 1 || vehicleType > 3)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }
            DateTime inTime = DateTime.Now;
            switch (vehicleType)
            {
                case 1:
                    vehicleTypeName = "TwoWheeler";
                    ParkTwoWheeler(vehicle.VehicleNumber, inTime);
                    break;
                case 2:
                    vehicleTypeName = "FourWheeler";
                    ParkFourWheeler(vehicle.VehicleNumber, inTime);
                    break;
                case 3:
                    vehicleTypeName = "HeavyVehicle";
                    ParkHeavyVehicle(vehicle.VehicleNumber, inTime);
                    break;
            }
            return null;
        }

        public void UnparkVehicle(string vehicleNumber)
        {
            switch (vehicleTypeName.ToLower())
            {
                case "twowheeler":
                    UnparkTwoWheeler(vehicleNumber);
                    break;
                case "fourwheeler":
                    UnparkFourWheeler(vehicleNumber);
                    break;
                case "heavyvehicle":
                    UnparkHeavyVehicle(vehicleNumber);
                    break;
                default:
                    Console.WriteLine("Invalid vehicle type.");
                    break;
            }
            Console.WriteLine($"Vehicle with number {vehicleNumber} unparked at {DateTime.Now}.");
        }
    }
}
