using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public int RoomId { get; set; }
        public String OwnerImageId { get; set; }
    }
}
