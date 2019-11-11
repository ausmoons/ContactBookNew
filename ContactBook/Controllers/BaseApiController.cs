using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ContactBook.Controllers
{
    public class BaseApiController : ApiController
    {

        public ContactService _contactService;

        public BaseApiController()
        {
            _contactService = new ContactService();
        }
        protected Contact ConvertDataToDomain(DataRequest dataRequest)
        {
            return new Contact
            {
                Id = dataRequest.Id,
                Name1 = dataRequest.Name1,
                Name2 = dataRequest.Name2,
                Surname1 = dataRequest.Surname1,
                Surname2 = dataRequest.Surname2,
                Notes = dataRequest.Notes,
                Birthday = dataRequest.Birthday,
                Company = dataRequest.Company,
                Photo = dataRequest.Photo,
                Emails = dataRequest.Email,
                Addresses = dataRequest.Address,
                PhoneNumbers = dataRequest.PhoneNumbers,
               

             };
        }


    }
}