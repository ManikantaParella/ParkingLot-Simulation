using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSimulation
{
    public class UserInterface
    {
        public static T GetInput<T>(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()??"";

                try
                {
                    T result = (T)Convert.ChangeType(input, typeof(T));

                    if (typeof(T) == typeof(int) && Convert.ToInt32(result) < 0)
                    {
                        Console.WriteLine(Messages.NegativeInput);
                        continue;
                    }

                    return result;
                }
                catch (FormatException)
                {
                    Console.WriteLine(Messages.InvalidInput);
                }
            }
        }
    }
    

}
