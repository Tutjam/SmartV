using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Sensor
    {
        [Required]
        [Key]
        public int SensorId { get; set; }

        [Required]
        public String SensorName { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public String OwnerSensorId { get; set; }
    }
}
