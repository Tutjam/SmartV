using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class SensorData
    {
        [Required]
        [Key]
        public int sensorDataId { get; set; }

        [Required]
        public int value { get; set; }

        [Required]
        public DateTime date { get; set; }
    }
}
