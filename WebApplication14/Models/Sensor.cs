using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Sensor
    {
        public int SensorId { get; set; }
        public String SensorName { get; set; }
        public int RoomId { get; set; }
    }
}
