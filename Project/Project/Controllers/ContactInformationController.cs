using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Helpers.Attributes;
using Project.Models.DTOs;
using Project.Models.Enums;
using Project.Models;
using Project.Services.ApartmentServices;
using Project.Services.ContactInformationServices;
using Microsoft.AspNetCore.Authorization;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationService _contactInformationService;

        public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }
        [HttpGet("contact-information")]
        public async Task<IActionResult> GetAllContactInformation()
        {
            var contactInformation = await _contactInformationService.GetAllContactInformation();
            return Ok(contactInformation);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(ContactInformationDTO contactInformation)
        {
            var contactInformationToCreate = new ContactInformation
            {
                PhoneNumber = contactInformation.PhoneNumber,
                EmergencyContactPhoneNumber = contactInformation.EmergencyContactPhoneNumber,
                UserId = contactInformation.UserId
            };

            await _contactInformationService.Create(contactInformationToCreate);
            return Ok();
        }
        [Authorization(Role.Admin, Role.User)]
        [HttpPut("edit/{id}")]
        public IActionResult EditContactInformation(Guid id, [FromBody] ContactInformationDTO contactInformation)
        {
            var contactInformationFound = _contactInformationService.GetById(id);
            if (contactInformationFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            contactInformationFound.PhoneNumber = contactInformation.PhoneNumber;
            contactInformationFound.EmergencyContactPhoneNumber = contactInformation.EmergencyContactPhoneNumber;
            contactInformationFound.UserId = contactInformation.UserId;
            if (_contactInformationService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
        [Authorization(Role.Admin, Role.User)]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteContactInformation(Guid id)
        {
            var contactInformationFound = _contactInformationService.GetById(id);
            if (contactInformationFound == null)
            {
                return BadRequest("The ID does not exist.");
            }
            _contactInformationService.Delete(contactInformationFound);
            if (_contactInformationService.Save() == false)
            {
                return BadRequest("Database error.");
            }
            return Ok();
        }
    }
}
