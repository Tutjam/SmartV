using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Models
{
    public class Room
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public String Name { get; set; }

        //[Required]
        public String OwnerId { get; set; }
    }
}
