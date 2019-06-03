using System.Collections.Generic;
using ContactWebApi.Models;
using ContactWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET api/contacts
        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            var contacts = _contactService.ReadContacts();
            return new JsonResult(contacts);
        }

        // GET api/contacts/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(int id)
        {
            var contact = _contactService.ReadContactById(id);
            return new JsonResult(contact);
        }

        // POST api/contacts
        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            var newContact = _contactService.CreateContact(contact);
            return new JsonResult(newContact);
        }

        // PUT api/contacts/5
        [HttpPut("{id}")]
        public ActionResult<Contact> Put(int id, Contact contact)
        {
            var updateContact = _contactService.UpdateContact(id, contact);
            return new JsonResult(updateContact);
        }

        // DELETE api/contacts/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _contactService.DeleteContact(id);
            return new OkResult();
        }
    }
}