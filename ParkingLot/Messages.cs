using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace ParkingLotSimulation
{
    public class Messages
    {
        public const string EnterVehicleNo = "Enter Vehicle Number:";
        public const string OccupancyDetails = "Current occupancy details:";
        public const string EnterVehicleNotoUnpark = "Enter Vehicle Number to Unpark:";
        public const string InvalidOption = "Invalid input. Please enter a number between 1 and 3.";
        public const string NoAvailableSlots = "No available slots.";
        public const string EnterVehicleType = "Enter Vehicle Type (1.TwoWheeler/ 2.FourWheeler/ 3.HeavyVehicle):";
        public const string InvalidVehicleType = "Invalid vehicle type. Please enter valid vehicle type.";
        public const string VehicleNumber = "Vehicle Number";
        public const string VehicleType = "Vehicle Type";
        public const string SlotNumber = "Slot Number";
        public const string InTime = "InTime";
        public const string OutTime = "OutTime";
        public const string Option = "Choose your Option: ";
        public const string Dash = "-------------------------------------";
        public const string NoOfTwoWheelerSlots = "Enter number of Two Wheeler Slots:";
        public const string NoOfFourWheelerSlots = "Enter number of Four Wheeler Slots:";
        public const string NoOfHeavyVehicleSlots = "Enter number of Heavy Vehicle Slots:";
        public const string TwoWheelerSlots = "2-wheeler slots";
        public const string FourWheelerSlots = "4-wheeler slots";
        public const string HeavyVehicleSlots = "Heavy vehicle slots";
        public const string Occupied = "Occupied";
        public const string Available = "Available";
        public const string Exit = "Exit";
        public const string InvalidInput = "Invalid input. Please try again.";
        public const string NegativeInput = "Negative numbers are not allowed. Please try again.";
        public const string ParkVehicle = "Park Vehicle";
        public const string UnParkVehicle = "UnPark Vehicle";

        public static string VehicleParked(string vehicleNumber , int slotNumber)
        {
            return $"Vehicle {vehicleNumber} parked at slot {slotNumber}";
        }

        public static string VehicleUnParked(string vehicleNumber, int slotNumber)
        {
            return $"Vehicle {vehicleNumber} unparked from slot {slotNumber}";
        }

        public static string VehicleNotFound(string vehicleNumber)
        {
            return $"Vehicle {vehicleNumber} not found.";
        }

        public static string VehicleUnparkedTime(string vehicleNumber , DateTime outTime)
        {
            return $"Vehicle with number {vehicleNumber} unparked at {outTime}.";
        }
    }
}
