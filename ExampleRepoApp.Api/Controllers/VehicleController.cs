using System.Linq;
using System.Threading.Tasks;
using ExampleRepoApp.BusinessLogic.Interfaces;
using ExampleRepoApp.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleRepoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _service;

        public VehicleController(IVehicleService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewVehicle(CreateVehicleModel vehicle)
        {
            await _service.CreateVehicle(vehicle);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetVehicleById(long id, bool extendedDetails)
        {
            var vehicle = extendedDetails
                ? await _service.GetExtendedVehicleById(id)
                : await _service.GetById(id);
            
            if (vehicle != null)
                return Ok(vehicle);

            return NotFound();
        }

        [HttpGet]
        [Route("make/{make}")]
        public async Task<IActionResult> GetVehiclesByMake(string make)
        {
            var vehicles = await _service.GetVehiclesByMake(make);
            if (vehicles.Any())
                return Ok(vehicles);

            return NoContent();
        }

        [HttpGet]
        [Route("model/{model}")]
        public async Task<IActionResult> GetVehiclesByModel(string model)
        {
            var vehicles = await _service.GetVehiclesByModel(model);
            if (vehicles.Any())
                return Ok(vehicles);

            return NoContent();
        }

        [HttpGet]
        [Route("type/{type}")]
        public async Task<IActionResult> GetVehiclesByType(string type)
        {
            var vehicles = await _service.GetVehiclesByType(type);
            if (vehicles.Any())
                return Ok(vehicles);

            return NoContent();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _service.GetAll();
            if (vehicles.Any())
                return Ok(vehicles);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVehicle(long id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}