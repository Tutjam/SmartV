using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome
{
    public static class TemperatureSimulator
    {
        public static int GetTemperature
        {
            Random rnd = new Random();
            return (rnd.Next(0,50) - 20)
        }
    }
}
