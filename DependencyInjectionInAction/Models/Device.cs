using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionInAction.Models
{
    public class Device
    {
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string DeviceLocation { get; set; }
        public string DeviceStatus { get; set; }
    }
}
