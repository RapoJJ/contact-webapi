using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using ContactWebApi.Models;
using ContactWebApi.Repositories;
using ContactWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;
        private readonly IContactService _contactService;

        public ContactsController(IContactRepository contactRepository, IContactService contactService)
        {
            _contactRepository = contactRepository;
            _contactService = contactService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Contact>> GetContacts()
        {
            return new JsonResult(_contactService.ReadContacts());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Contact> Get(long id)
        {
            var contact = _contactService.ReadContactById(id);
            return new JsonResult(contact);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Contact> Post(Contact contact)
        {
            var newContact = _contactService.CreateContact(contact);
            return new JsonResult(newContact);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Contact> Put(long id, Contact contact)
        {
            var updateContact = _contactService.UpdateContact(id, contact);
            return new JsonResult(updateContact);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            _contactService.DeleteContact(id);
            return new NoContentResult();
        }
    }
}