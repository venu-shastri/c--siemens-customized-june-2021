using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionInAction.Repository
{
    public class DeviceInMemoryRepository
    {
        List<Models.Device> _deviceStorage = new List<Models.Device>()
        {
            new Models.Device{ DeviceId="D1", DeviceName="ABC", DeviceLocation="L1", DeviceStatus="Active"},
            new Models.Device{ DeviceId="D2", DeviceName="ABC", DeviceLocation="L1", DeviceStatus="Active"},
            new Models.Device{ DeviceId="D3", DeviceName="XYZ", DeviceLocation="L2", DeviceStatus="Halted"},
            new Models.Device{ DeviceId="D4", DeviceName="PQR", DeviceLocation="L3", DeviceStatus="Stopped"}
        };

        public IEnumerable<Models.Device> GetAllDevices() { return _deviceStorage; }


    }
}
