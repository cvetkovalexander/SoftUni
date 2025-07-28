using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarManufacturer
{
    public  class Engine
    {
        public Engine(int horse, double cubic)
        {
            HorsePower = horse;
            CubicCapacity = cubic;
        }
        private int horsePower;
        private double cubicCapacity;

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }
    }
}
