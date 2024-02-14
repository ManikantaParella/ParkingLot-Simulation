using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace ParkingLotSimulation
{
    public class ParkingLot
    {
        private int twoWheelerCapacity;
        private int fourWheelerCapacity;
        private int heavyVehicleCapacity;
        private VehicleType vehicleTypeName;
        private int totalVehicleSlots;
        private List<IParkingSlot> vehicleParkingSlots;
        private List<ParkingTicket> ParkingTickets;

        public ParkingLot(int numTwoWheelerSlots, int numFourWheelerSlots, int numHeavyVehicleSlots)
        {
            twoWheelerCapacity = numTwoWheelerSlots;
            fourWheelerCapacity = numFourWheelerSlots;
            heavyVehicleCapacity = numHeavyVehicleSlots;
            totalVehicleSlots = numTwoWheelerSlots+numFourWheelerSlots+numHeavyVehicleSlots;
            vehicleParkingSlots = new List<IParkingSlot>();
            ParkingTickets = new List<ParkingTicket>();
            InitializeParkingSlots();
        }

        private void InitializeParkingSlots()
        {
            for (int i = 1; i <= totalVehicleSlots; i++)
            {
                vehicleParkingSlots.Add(new ParkingSlot());
            }
        }

        public void CheckOccupancyDetails()
        {
            Console.WriteLine(Messages.OccupancyDetails);
            Console.WriteLine(Messages.Dash);
            Console.WriteLine($"{Messages.TwoWheelerSlots}: {GetOccupiedSlotsCount(VehicleType.TwoWheeler)} {Messages.Occupied}, {twoWheelerCapacity - GetOccupiedSlotsCount(VehicleType.TwoWheeler)} {Messages.Available}");
            Console.WriteLine($"{Messages.FourWheelerSlots}: {GetOccupiedSlotsCount(VehicleType.FourWheeler)} {Messages.Occupied}, {fourWheelerCapacity - GetOccupiedSlotsCount(VehicleType.FourWheeler)} {Messages.Available}");
            Console.WriteLine($"{Messages.HeavyVehicleSlots}: {GetOccupiedSlotsCount(VehicleType.HeavyVehicle)} {Messages.Occupied}, {heavyVehicleCapacity - GetOccupiedSlotsCount(VehicleType.HeavyVehicle)} {Messages.Available}");
            Console.WriteLine($"{Messages.Dash}\n");
        }

        private int GetOccupiedSlotsCount(VehicleType vehicleType)
        {
            return vehicleParkingSlots.Count(slot => slot.IsOccupied && ((ParkingSlot)slot).VehicleType==vehicleType);
        }

       

        private void ParkVehicle(string vehicleNumber,VehicleType vehicleType, DateTime inTime, List<IParkingSlot> slots)
        {   
            Console.WriteLine(slots.Count);
            IParkingSlot? slot = slots.FirstOrDefault(s => !s.IsOccupied);
            Console.WriteLine(vehicleType);
            if (slot != null)
            {
                slot.Park(vehicleNumber,vehicleType);
                ParkingTicket ticketDetails = new ParkingTicket(vehicleNumber, vehicleTypeName, slots.IndexOf(slot) + 1, DateTime.Now, DateTime.MinValue);
                ParkingTickets.Add(ticketDetails);
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
            ParkingTicket? ticketCollection = ParkingTickets.FirstOrDefault(s => s.VehicleNumber == vehicleNumber);
            DateTime inTime = ticketCollection.InTime;
            ParkingTickets.Remove(ticketCollection);
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

        public void ParkTwoWheeler(string vehicleNumber,VehicleType vehicleType, DateTime inTime)
        {
            List<IParkingSlot> twoWheelerSlots = vehicleParkingSlots.Take(twoWheelerCapacity).Where(slot => !slot.IsOccupied).ToList();
            ParkVehicle(vehicleNumber, vehicleType, inTime, twoWheelerSlots);

        }

        public void ParkFourWheeler(string vehicleNumber, VehicleType vehicleType, DateTime inTime)
        {
            List<IParkingSlot> fourWheelerSlots = vehicleParkingSlots.Skip(twoWheelerCapacity).Take(fourWheelerCapacity).Where(slot => !slot.IsOccupied).ToList();
            ParkVehicle(vehicleNumber, vehicleType, inTime, fourWheelerSlots);
        }

        public void ParkHeavyVehicle(string vehicleNumber, VehicleType vehicleType, DateTime inTime)
        {   List<IParkingSlot> heavyVehicleSlots = vehicleParkingSlots.Skip(twoWheelerCapacity+fourWheelerCapacity).Take(heavyVehicleCapacity).Where(slot => !slot.IsOccupied).ToList();
            ParkVehicle(vehicleNumber, vehicleType, inTime, heavyVehicleSlots);
        }

        public void UnparkTwoWheeler(string vehicleNumber)
        {
            UnparkVehicle(vehicleNumber, vehicleParkingSlots);
        }

        public void UnparkFourWheeler(string vehicleNumber)
        {
            UnparkVehicle(vehicleNumber, vehicleParkingSlots);
        }

        public void UnparkHeavyVehicle(string vehicleNumber)
        {
            UnparkVehicle(vehicleNumber, vehicleParkingSlots);
        }

        public void ParkVehicle(IVehicle vehicle)
        {
            Console.WriteLine($"{Messages.EnterVehicleNo}: {vehicle.VehicleNumber}");

            int vehicleType = UserInterface.GetInput<int>(Messages.EnterVehicleType);
            DateTime inTime = DateTime.Now;

            switch (vehicleType)
            {
                case 1:
                    vehicleTypeName = VehicleType.TwoWheeler;
                    ParkTwoWheeler(vehicle.VehicleNumber,vehicleTypeName, inTime);
                    break;
                case 2:
                    vehicleTypeName = VehicleType.FourWheeler;
                    ParkFourWheeler(vehicle.VehicleNumber, vehicleTypeName, inTime);
                    break;
                case 3:
                    vehicleTypeName = VehicleType.HeavyVehicle;
                    ParkHeavyVehicle(vehicle.VehicleNumber, vehicleTypeName, inTime);
                    break;
                default:
                    Console.WriteLine(Messages.InvalidOption);
                    break;
            }

        }

        public void UnparkVehicle(string vehicleNumber)
        {
            switch (vehicleTypeName)
            {
                case VehicleType.TwoWheeler:
                    UnparkTwoWheeler(vehicleNumber);
                    break;
                case VehicleType.FourWheeler:
                    UnparkFourWheeler(vehicleNumber);
                    break;
                case VehicleType.HeavyVehicle:
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
