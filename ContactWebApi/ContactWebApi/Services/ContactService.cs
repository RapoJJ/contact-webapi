using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Models;
using ContactWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact CreateContact(Contact contact)
        {
            return _contactRepository.Create(contact);
        }

        public List<Contact> ReadContacts()
        {
            return _contactRepository.Read();
        }

        public Contact ReadContactById(long id)
        {
            return _contactRepository.Read(id);
        }

        public Contact UpdateContact(long id, Contact contact)
        {
            var updatedContact = _contactRepository.Read(id);

            if (updatedContact == null)
            {
                //EI OLLU OLEMASSA
                throw new Exception($"Contact with {id} not found!");
            }

            return _contactRepository.Update(contact);
        }

        public StatusCodeResult DeleteContact(long id)
        {
            var deletedContact = _contactRepository.Read(id);
            if (deletedContact == null)
            {
                throw new Exception("Contact not found");
            }

            return _contactRepository.Delete(id);
        }
    }
}
