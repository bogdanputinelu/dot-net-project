using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Helpers.Attributes;
using Project.Models.DTOs;
using Project.Models.Enums;
using Project.Models;
using Project.Services.ApartmentServices;
using Project.Services.LeasedServices;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeasedController : ControllerBase
    {
        private readonly ILeasedService _leasedService;

        public LeasedController(ILeasedService leasedService)
        {
            _leasedService = leasedService;
        }
        [Authorization(Role.Admin)]
        [HttpGet("leased")]
        public async Task<IActionResult> GetAllLeased()
        {
            var leased = await _leasedService.GetAllLeased();
            return Ok(leased);
        }
        [Authorization(Role.Admin)]
        [HttpPost("create")]
        public async Task<IActionResult> Create(LeasedRequestDTO leased)
        {
            var leasedToCreate = new Leased
            {
                UserId = leased.UserId,
                ApartmentId = leased.ApartmentId,
                People = leased.People,
            };
            

            await _leasedService.Create(leasedToCreate);
            return Ok();
        }
        [Authorization(Role.Admin)]
        [HttpPut("edit/{id1}/{id2}")]
        public IActionResult EditLeased(Guid id1, Guid id2, [FromBody] LeasedRequestDTO leased)
        {
            var leasedFound = _leasedService.GetById(id1, id2);
            if (leasedFound == null)
            {
                leasedFound = _leasedService.GetById(id2, id1);
                if (leasedFound == null)
                {
                    return BadRequest("The ID does not exist.");
                }
            }
            leasedFound.People = leased.People;
            if (_leasedService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
        [Authorization(Role.Admin)]
        [HttpDelete("delete/{id1}/{id2}")]
        public IActionResult DeleteLeased(Guid id1,Guid id2)
        {
            var leaseFound = _leasedService.GetById(id1, id2);
            if (leaseFound == null)
            {
                leaseFound = _leasedService.GetById(id2, id1);
                if (leaseFound == null)
                {
                    return BadRequest("The ID does not exist.");
                }
            }
            _leasedService.Delete(leaseFound);
            if (_leasedService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
    }
}
