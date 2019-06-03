using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Models;
using ContactWebApi.Repositories;

namespace ContactWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<Contact> ReadContacts()
        {
            return _contactRepository.Read();
        }

        public Contact ReadContactById(int id)
        {
            return _contactRepository.Read(id);
        }

        public Contact CreateContact(Contact contact)
        {
            return _contactRepository.Create(contact);
        }

        public Contact UpdateContact(int id, Contact contact)
        {
            var updatedContact = _contactRepository.Read(id);

            if (updatedContact == null)
            {
                //EI OLLU OLEMASSA
                throw new Exception($"Contact with {id} not found!");
            }
            else
            {
                return _contactRepository.Update(contact);
            }
        }

        public void DeleteContact(int id)
        {
            _contactRepository.Delete(id);
        }
    }
}
