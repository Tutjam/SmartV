using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Room
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String OwnerId { get; set; }
    }
}
