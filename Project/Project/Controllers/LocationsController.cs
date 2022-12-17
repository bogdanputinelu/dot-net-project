using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.DTOs;
using Project.Models;
using Project.Services.LocationServices;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        [HttpGet("locations")]
        public async Task<IActionResult> GetAllLocations()
        {
            var locations = await _locationService.GetAllLocations();
            return Ok(locations);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(LocationRequestDTO location)
        {
            var locationToCreate = new Location
            {
                Country = location.Country,
                City = location.City
            };

            await _locationService.Create(locationToCreate);
            return Ok();
        }
        [HttpPut("edit/{id}")]
        public IActionResult EditLocation(Guid id, [FromBody] LocationRequestDTO location)
        {
            var locationFound = _locationService.GetById(id);
            if (locationFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            locationFound.Country = location.Country;
            locationFound.City = location.City;
            if (_locationService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteLocation(Guid id)
        {
            var locationFound = _locationService.GetById(id);
            if (locationFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            _locationService.Delete(locationFound);
            if (_locationService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
    }
}
