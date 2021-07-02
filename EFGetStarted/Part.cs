using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    public class Part
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }


        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
