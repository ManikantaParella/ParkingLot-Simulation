using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IParkingSlot
    {
        bool IsOccupied { get; }
        string VehicleNumber { get; set; }
        VehicleType VehicleType { get; set; }
        void Park(string vehicleNumber , VehicleType VehicleType);
        void Unpark();
    }
}
