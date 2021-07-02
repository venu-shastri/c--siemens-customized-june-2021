using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    public class Device
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<Part> Parts { get; } = new List<Part>();
    }
}
