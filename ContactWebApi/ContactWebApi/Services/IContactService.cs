using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Services
{
    public interface IContactService
    {
        //CRUD
        Contact CreateContact(Contact contact);
        List<Contact> ReadContacts();
        Contact ReadContactById(long id);       
        Contact UpdateContact(long id, Contact contact);
        StatusCodeResult DeleteContact(long id);
    }
}
