using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactWebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactWebApi.Repositories
{
    public interface IContactRepository
    {
        //CRUD
        Contact Create(Contact contact);
        List<Contact> Read();
        Contact Read(long id);
        Contact Update(Contact contact);
        StatusCodeResult Delete(long id);
    }
}
