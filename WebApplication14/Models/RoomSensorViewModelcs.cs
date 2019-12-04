using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class RoomSensorViewModelcs
    {

        public Room roomId { get; set; }
        public Room roomName { get; set; }
        public Room ownerId { get; set; }
        public Sensor sensorId { get; set; }
        public Sensor sensorName { get; set; }
    }
}
