using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using ContactBook.Models;

namespace ContactBook.Controllers
{
    public class ContactController : BaseApiController
    {
        public ContactController()
        {
            _contactService = new ContactService();
        }


        [HttpGet]
        [Route("api/Data/id/{id}")]
        public async Task<HttpResponseMessage> GetById(HttpRequestMessage request, int id)
        {
            var contact = await _contactService.FindContactById(id);
            if (contact == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, contact);
            }

            return request.CreateResponse(HttpStatusCode.OK, contact);
        }

        [HttpGet]
        [Route("api/Data/name/{name1}")]
        public async Task<HttpResponseMessage> GetByName1(HttpRequestMessage request, string name1)
        {
            var contact = await _contactService.FindContactByName1(name1);
            if (contact == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, contact);
            }

            return request.CreateResponse(HttpStatusCode.OK, contact);
        }

        [HttpGet]
        [Route("api/Data/surname/{surname1}")]
        public async Task<HttpResponseMessage> GetBySurname1(HttpRequestMessage request, string surname1)
        {
            var contact = await _contactService.FindContactBySurname1(surname1);
            if (contact == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, contact);
            }

            return request.CreateResponse(HttpStatusCode.OK, contact);
        }
        [HttpGet]
        [Route("api/Data/company/{company}")]
        public async Task<HttpResponseMessage> GetByCompany(HttpRequestMessage request, string company)
        {
            var contact = await _contactService.FindContactByCompany(company);
            if (contact == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, contact);
            }

            return request.CreateResponse(HttpStatusCode.OK, contact);
        }
        [HttpGet]
        [Route("api/Data/phoneNumber/{phoneNumber}")]
        public async Task<HttpResponseMessage> GetByPhoneNmber(HttpRequestMessage request, string phoneNumber)
        {
            var contact = await _contactService.FindContactByPhone(phoneNumber);
            if (contact == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, contact);
            }

            return request.CreateResponse(HttpStatusCode.OK, contact);
        }

        [HttpGet]
        [Route("api/Data/email/{email}")]
        public async Task<HttpResponseMessage> GetByEmail(HttpRequestMessage request, string email)
        {
            var contact = await _contactService.FindContactByEmail(email);
            if (contact == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, contact);
            }

            return request.CreateResponse(HttpStatusCode.OK, contact);
        }



        [HttpGet]
        [Route("api/Data/All")]
        public async Task<IHttpActionResult> GetAllContacts()
        {
            var contacts = await _contactService.FindAllContacts();
            return Ok(contacts.ToList());
        }


        
        [HttpPost]
        [Route("api/Data")]
        public IHttpActionResult AddContact(Contact contact)
        {
            if (!IsValid(contact))
            {
                return BadRequest();
            }

            var result = _contactService.AddContact(contact);
            if (!result.Succeeded) 
            {
                return Conflict();
            }
            contact.Id = result.Id; 
            return Created(string.Empty, contact);

        }


        [HttpPut]
        [Route("api/Data/update")]
        public IHttpActionResult UpdateContact(Contact contact)
        {
            if (!IsValid(contact))
            {
                return BadRequest();
            }
            
            var result =  _contactService.Update(contact);         
            return Ok();

        }

        [HttpPut]
        [Route("api/Data/update")]
        public IHttpActionResult UpdateEmail(ICollection<Emails> emails)
        {
            if (!IsValidEmail(emails))
            {
                return BadRequest();
            }

            var result = _contactService.UpdateEmailService(emails);
            return Ok();

        }


        public bool IsValid(Contact contact)
        {
            return !string.IsNullOrEmpty(contact.Name1) &&
                     !string.IsNullOrEmpty(contact.Surname1) &&
            IsValidPhone(contact.PhoneNumbers) &&  IsValidAddress(contact.Addresses) &&
            IsValidEmail(contact.Emails) && ISValidDate(contact.Birthday);
        }

        private bool ISValidDate(DateTime? birthday)
        {
            bool isValid = true;
            if (birthday != null)
            {
               if( birthday <= DateTime.Now)
                {
                    isValid = true;
                }
                isValid = false;
            }
            return isValid;
        }

        public bool IsValidEmail(ICollection<Emails> emails)
        {
            var isValid = true;
            foreach (var emailAddress in emails)
            {
                isValid = emailAddress.EmailAddress.Contains("@") && emailAddress.EmailAddress.Contains(".");
                if (isValid == false)
                {
                    isValid = false;
                }

            }
            return isValid;
        }

        private  bool IsValidAddress(ICollection<Addresses> addresses) //google always return postal code
        {//maybe compare user given postal code with google?
            var street = "";
            var houseNumber = "";
            var city = "";
           
           foreach (var item in addresses)
            {
                street = item.Street;
                houseNumber = item.HouseNumber;
                city = item.City;         
            }

            const string url = @"https://maps.googleapis.com/maps/api/geocode/xml?address=Latvija+{city}+{street}+{houseNumber}&key=AIzaSyBhwgkjOOK6Qb6D4eLVk1oROcFMK35UD0E&language=lv";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = request.GetResponse();
            var webStream = webResponse.GetResponseStream();
            var responseReader = new StreamReader(webStream);
            var response = responseReader.ReadToEnd();


            responseReader.Close();

            return true;             
        }


        private bool IsValidPhone(ICollection<PhoneNumbers> phone)
        {
            bool isValid = true;
            bool allDigits = true;
            bool startsWith = true;
            bool numberLenght = true;
            foreach (var phoneNumber in phone)
            {
                foreach (char c in phoneNumber.PhoneNumber)
                {
                    if (!char.IsDigit(c))
                    {
                        allDigits = false;
                    }
                }

                if (phoneNumber.PhoneNumber[0] != 2)
                {
                    startsWith = false;
                }

                if (phoneNumber.PhoneNumber.Length != 8)
                {
                    numberLenght = false;
                }

            }

            if (allDigits == true && startsWith == true && numberLenght == true)
            {
                return isValid = true;
            }
            return isValid;

        }

        [HttpDelete]
        [Route("api/Data/{id}")]
        public async Task<HttpResponseMessage> DeleteByID(HttpRequestMessage request, int id)
        {

            await _contactService.RemoveContactById(id);
            return request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/Data/name/{name1}")]
        public async Task<HttpResponseMessage> DeleteByName1(HttpRequestMessage request, string name1)
        {
            await _contactService.RemoveContactByName1(name1);
            return request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/Data/surname/{surname1}")]
        public async Task<HttpResponseMessage> DeleteBySurname1(HttpRequestMessage request, string surname1)
        {
            await _contactService.RemoveContactBySurname1(surname1);
            return request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/Data/deleteAll")]
        public async Task<bool> Clear()
        {
            await _contactService.DeleteAllContacts();
            return true;
        }
    }
}
