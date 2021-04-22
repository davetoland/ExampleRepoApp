using System.Linq;
using System.Threading.Tasks;
using ExampleRepoApp.BusinessLogic.Interfaces;
using ExampleRepoApp.BusinessLogic.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleRepoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _service;

        public OwnerController(IOwnerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewOwner(CreateOwnerModel owner)
        {
            await _service.CreateOwner(owner);
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetOwnerById(long id, bool extendedDetails)
        {
            var owner = extendedDetails
            ? await _service.GetById(id)
            : await _service.GetExtendedOwnerById(id);
            
            if (owner != null)
                return Ok(owner);

            return NotFound();
        }

        [HttpGet]
        [Route("email/{email}")]
        public async Task<IActionResult> GetOwnerByEmail(string email)
        {
            var owner = await _service.GetOwnerByEmail(email);
            if (owner != null)
                return Ok(owner);

            return NotFound();
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var owners = await _service.GetAll();
            if (owners.Any())
                return Ok(owners);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOwner(long id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}