using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ParkingLotSimulation
{
    public class ParkingLot
    {
        private int twoWheelerCapacity;
        private int fourWheelerCapacity;
        private int heavyVehicleCapacity;
        private string vehicleTypeName;
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
            Console.WriteLine(Messages.OccupancyDetails);
            Console.WriteLine(Messages.Dash);
            Console.WriteLine($"{Messages.TwoWheelerSlots}: {GetOccupiedSlotsCount(twoWheelerSlots)} {Messages.Occupied}, {twoWheelerCapacity - GetOccupiedSlotsCount(twoWheelerSlots)} {Messages.Available}");
            Console.WriteLine($"{Messages.FourWheelerSlots}: {GetOccupiedSlotsCount(fourWheelerSlots)} {Messages.Occupied}, {fourWheelerCapacity - GetOccupiedSlotsCount(fourWheelerSlots)} {Messages.Available}");
            Console.WriteLine($"{Messages.HeavyVehicleSlots}: {GetOccupiedSlotsCount(heavyVehicleSlots)} {Messages.Occupied}, {heavyVehicleCapacity - GetOccupiedSlotsCount(heavyVehicleSlots)} {Messages.Available}");
            Console.WriteLine($"{Messages.Dash}\n");
        }

        private int GetOccupiedSlotsCount(List<IParkingSlot> slots)
        {
            return slots.Count(slot => slot.IsOccupied);
        }

        private void ParkVehicle(string vehicleNumber, DateTime inTime, List<IParkingSlot> slots)
        {
            IParkingSlot? slot = slots.FirstOrDefault(s => !s.IsOccupied);
            if (slot != null)
            {
                slot.Park(vehicleNumber);
                vehicleParkingTimes.Add(vehicleNumber, inTime);
                ParkingTicket ticketDetails = new ParkingTicket(vehicleNumber, vehicleTypeName, slots.IndexOf(slot) + 1, DateTime.Now, DateTime.MinValue);
                ParkingTicketService ticket = new ParkingTicketService(ticketDetails);
                ticket.DisplayTicket();
                Console.WriteLine(Messages.VehicleParked(vehicleNumber, slots.IndexOf(slot) + 1));
            }
            else
            {
                Console.WriteLine(Messages.NoAvailableSlots);
            }
        }

        private void UnparkVehicle(string vehicleNumber, List<IParkingSlot> slots)
        {
            IParkingSlot? slot = slots.FirstOrDefault(s => s.IsOccupied && ((ParkingSlot)s).VehicleNumber == vehicleNumber);
            DateTime inTime = vehicleParkingTimes[vehicleNumber];
            vehicleParkingTimes.Remove(vehicleNumber);
            if (slot != null)
            {
                slot.Unpark();
                ParkingTicket ticketDetails = new ParkingTicket(vehicleNumber, vehicleTypeName, slots.IndexOf(slot) + 1, inTime, DateTime.Now);
                ParkingTicketService ticket = new ParkingTicketService(ticketDetails);
                ticket.DisplayTicket();
                Console.WriteLine(Messages.VehicleUnParked(vehicleNumber, slots.IndexOf(slot) + 1));
            }
            else
            {
                Console.WriteLine(Messages.VehicleNotFound(vehicleNumber));
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

        public void ParkVehicle(IVehicle vehicle)
        {
            Console.WriteLine($"{Messages.EnterVehicleNo}: {vehicle.VehicleNumber}");

            int vehicleType = UserInterface.GetInput<int>(Messages.EnterVehicleType);
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
                default:
                    Console.WriteLine(Messages.InvalidOption);
                    break;
            }

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
                    Console.WriteLine(Messages.InvalidVehicleType);
                    break;
            }
            Console.WriteLine(Messages.VehicleUnparkedTime(vehicleNumber, DateTime.Now));
        }
    }
}
