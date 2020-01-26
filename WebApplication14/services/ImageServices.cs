using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication14.Data;

namespace SmartHome.services
{
    public class ImageServices
    {
        private readonly ApplicationDbContext _ctx;

        public ImageServices(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

       
    }
}
