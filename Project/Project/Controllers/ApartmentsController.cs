using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models.DTOs;
using Project.Models.Enums;
using Project.Models;
using Project.Services.ApartmentServices;
using Project.Services.UserServices;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        [HttpGet("apartments")]
        public async Task<IActionResult> GetAllApartments()
        {
            var apartments = await _apartmentService.GetAllApartments();
            return Ok(apartments);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ApartmentRequestDTO apartment)
        {
            var apartmentToCreate = new Apartment
            {
                Name = apartment.Name,
                Price = apartment.Price,
                Floor = apartment.Floor,
                NumberOfBathrooms = apartment.NumberOfBathrooms,
                NumberOfRooms = apartment.NumberOfRooms,
                SquareMeters = apartment.SquareMeters,
                LocationId = apartment.LocationId
            };
            
            await _apartmentService.Create(apartmentToCreate);
            return Ok();
        }
        [HttpPut("edit/{id}")]
        public IActionResult EditApartment(Guid id, [FromBody] ApartmentRequestDTO apartment)
        {
            var apartmentFound = _apartmentService.GetById(id);
            if (apartmentFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            apartmentFound.Name = apartment.Name;
            apartmentFound.Price = apartment.Price;
            apartmentFound.Floor = apartment.Floor;
            apartmentFound.NumberOfBathrooms = apartment.NumberOfBathrooms;
            apartmentFound.NumberOfRooms = apartment.NumberOfRooms;
            apartmentFound.SquareMeters = apartment.SquareMeters;
            apartmentFound.LocationId = apartment.LocationId;
            if (_apartmentService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteApartment(Guid id)
        {
            var apartmentFound = _apartmentService.GetById(id);
            if (apartmentFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            _apartmentService.Delete(apartmentFound);
            if (_apartmentService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
    }
}
