using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Models;

namespace ContactWebApi.Services
{
    public interface IContactService
    {
        //CRUD
        List<Contact> ReadContacts();
        Contact ReadContactById(int id);
        Contact CreateContact(Contact contact);
        Contact UpdateContact(int id, Contact contact);
        void DeleteContact(int id);
    }
}
