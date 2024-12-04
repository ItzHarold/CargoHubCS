using System.Collections.Generic;
using Backend.Features.Contacts;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.Contacts
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = _contactService.GetAllContacts();
            return Ok(contacts);
        }
    }
}
