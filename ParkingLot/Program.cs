using ParkingLotSimulation;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter number of Two Wheeler Slots:");
        int numTwoWheelerSlots;
        while (!int.TryParse(Console.ReadLine(), out numTwoWheelerSlots) || numTwoWheelerSlots <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer value.");
        }

        Console.WriteLine("Enter number of Four Wheeler Slots:");
        int numFourWheelerSlots;
        while (!int.TryParse(Console.ReadLine(), out numFourWheelerSlots) || numFourWheelerSlots <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer value.");
        }

        Console.WriteLine("Enter number of Heavy Vehicle Slots:");
        int numHeavyVehicleSlots;
        while (!int.TryParse(Console.ReadLine(), out numHeavyVehicleSlots) || numHeavyVehicleSlots <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive integer value.");
        }

        ParkingLot parkingLot = new ParkingLot(numTwoWheelerSlots, numFourWheelerSlots, numHeavyVehicleSlots);

        while (true)
        {
            Console.WriteLine("\nChoose your Option");
            Console.WriteLine("1. Park Vehicle");
            Console.WriteLine("2. UnPark Vehicle");
            Console.WriteLine("3. Exit");

            int option;
            while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
            }

            switch (option)
            {
                case 1:
                    parkingLot.ParkVehicle(GetVehicle());
                    parkingLot.CheckOccupancyDetails();
                    break;
                case 2:
                    Console.WriteLine("Enter Vehicle Number to Unpark:");
                    string vehicleNumber = Console.ReadLine();
                    parkingLot.UnparkVehicle(vehicleNumber);
                    parkingLot.CheckOccupancyDetails();
                    break;
                case 3:
                    return;
            }
        }
    }

    static IVehicle GetVehicle()
    {
        Console.WriteLine("Enter Vehicle Number:");
        string vehicleNumber = Console.ReadLine();

        return new TwoWheeler(vehicleNumber);
    }
}