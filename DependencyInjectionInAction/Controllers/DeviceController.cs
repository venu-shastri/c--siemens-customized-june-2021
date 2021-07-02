using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionInAction.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        Repository.DeviceInMemoryRepository _repo = new Repository.DeviceInMemoryRepository();
        [HttpGet]
        public IEnumerable<Models.Device> GetAll()
        {
            return _repo.GetAllDevices();

        }
    }
}
