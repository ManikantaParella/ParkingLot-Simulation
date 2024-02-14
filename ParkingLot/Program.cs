using ParkingLotSimulation;
using Model;

class Program
{
    static void Main(string[] args)
    {
        int numTwoWheelerSlots = UserInterface.GetInput<int>(Messages.NoOfTwoWheelerSlots);
        int numFourWheelerSlots = UserInterface.GetInput<int>(Messages.NoOfFourWheelerSlots);
        int numHeavyVehicleSlots = UserInterface.GetInput<int>(Messages.NoOfHeavyVehicleSlots);

        ParkingLot parkingLot = new ParkingLot(numTwoWheelerSlots, numFourWheelerSlots, numHeavyVehicleSlots);

        while (true)
        {

            Console.WriteLine($"1.{Messages.ParkVehicle}");
            Console.WriteLine($"2.{Messages.UnParkVehicle}");
            Console.WriteLine($"3.{Messages.Exit}");

            int option = UserInterface.GetInput<int>(Messages.Option);
            switch (option)
            {
                case 1:
                    parkingLot.ParkVehicle(GetVehicle());
                    parkingLot.CheckOccupancyDetails();
                    break;
                case 2:

                    string vehicleNumber = UserInterface.GetInput<string>(Messages.EnterVehicleNotoUnpark);
                    parkingLot.UnparkVehicle(vehicleNumber);
                    parkingLot.CheckOccupancyDetails();
                    break;
                case 3:
                    return;
                default:
                    Console.WriteLine(Messages.InvalidOption);
                    break;
            }
        }
    }

    static IVehicle GetVehicle()
    {

        string vehicleNumber = UserInterface.GetInput<string>(Messages.EnterVehicleNo);

        return new TwoWheeler(vehicleNumber);
    }
}