using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ContactBook.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ContactBook.Controllers
{
    public class ContactController : BaseApiController
    {
        public ContactController()
        {
            _contactService = new ContactService();
        }


        [HttpGet]
        [Route("api/Contact/id/{id}")]
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
        [Route("api/Contact/{name1}")]
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
        [Route("api/Contact/{surname1}")]
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
        [Route("api/Contact/{company}")]
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
        [Route("api/Contact/{phoneNumber}")]
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
        [Route("api/Contact/email/{email}")]
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
        [Route("api/Contact/All")]
        public async Task<IHttpActionResult> GetAllContacts()
        {
            var contacts = await _contactService.FindAllContacts();
            return Ok(contacts.ToList());
        }


        
        [HttpPost]
        [Route("api/Contact")]
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
        [Route("api/Contact/update/id/{id}")]
        public IHttpActionResult UpdateContact(int id, Contact contact)
        {

            var contactToUpdate = _contactService.FindContactById(id);

            if (contactToUpdate == null)
            {
                return BadRequest();
            }
            else
            {
                var result = _contactService.Update(id, contact);
                if (!result.Succeeded)
                {
                    return Conflict();
                }
                contact.Id = result.Id;
                return Created(string.Empty, contact);
            }
            
            

        }

        [HttpPost]
        [Route("api/Contact/update/email/{emailID}")]
        public IHttpActionResult UpdateEmail(ICollection<Emails> email, int EmailID)
        {
            if (!IsValidEmail(email))
            {
                return BadRequest();
            }

            var result = _contactService.UpdateEmailService(email, EmailID); //
            return Ok(result);

        }

        [HttpPost]
        [Route("api/Contact/update")]
        public IHttpActionResult UpdateAddress(ICollection<Addresses> address, int addressID)
        {
            if (!IsValidAddress(address))
            {
                return BadRequest();
            }

            var result = _contactService.UpdateAddressService(address, addressID);
            return Ok(result);

        }

        [HttpPost]
        [Route("api/Contact/update")]
        public IHttpActionResult UpdatePhone(ICollection<PhoneNumbers> phoneNumber, int phoneNumberID)
        {
            if (!IsValidPhone(phoneNumber))
            {
                return BadRequest();
            }

            var result = _contactService.UpdatePhoneService(phoneNumber, phoneNumberID);
            return Ok(result);

        }


        public bool IsValid(Contact contact)
        {
            return !string.IsNullOrEmpty(contact.Name1) &&
                     !string.IsNullOrEmpty(contact.Surname1) &&
            IsValidPhone(contact.PhoneNumbers) &&  IsValidAddress(contact.Addresses) &&
            IsValidEmail(contact.Emails) && IsValidDate(contact.Birthday);
        }

        public bool IsValidDate(DateTime? birthday)
        {
            bool isValid = true;
            if (birthday != null)
            {
               if( birthday <= DateTime.Now)
               {
                    isValid = true;
               }
                else
                {
                    isValid = false;
                }

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

        public  bool IsValidAddress(ICollection<Addresses> addresses) 
        {
            var street = "";
            var houseNumber = "";
            var city = "";
            var postalCode = "";
            bool isValid = true;



                foreach (var item in addresses)
                {
                    street = item.Street;
                    houseNumber = item.HouseNumber;
                    city = item.City;
                    postalCode = item.PostalCode;
                }

            if (!string.IsNullOrEmpty(street) && !string.IsNullOrEmpty(houseNumber) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(street))
            {

                string url = $"https://maps.googleapis.com/maps/api/geocode/json?address=Latvija+{city}+{street}+{houseNumber}&key=AIzaSyBhwgkjOOK6Qb6D4eLVk1oROcFMK35UD0E&language=lv";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                var webResponse = request.GetResponse();
                var webStream = webResponse.GetResponseStream();
                var responseReader = new StreamReader(webStream);
                var response = responseReader.ReadToEnd();

                DeserializeJson(response);

                var postalCodeFound = DeserializeJson(response).postal_Code;

                var postalCodeNumbers = String.Join("", postalCode.Where(char.IsDigit));
                if (postalCodeFound != postalCodeNumbers)
                {
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

                responseReader.Close();

            }
            return isValid;             
        }


        private JsonAdressResponseModel DeserializeJson(string response)//
        {
            

                var obj = JsonConvert.DeserializeObject<RootObject>(response);
                List<JsonAdressResponseModel> result = obj.results.Select(x => new JsonAdressResponseModel
                {
                    address_Components = x.address_components,
                    Status = obj.status,
                    lat = x.geometry.location.lat,
                    lng = x.geometry.location.lng,
                    postal_Code = x.address_components[5].long_name
                }).ToList();
                if (result.Count == 0)
                    return new JsonAdressResponseModel()
                    {
                        Status = obj.status
                    };
                return new JsonAdressResponseModel()
                {
                    address_Components = result[0].address_Components,
                    Status = obj.status,
                    lat = result[0].lat,
                    lng = result[0].lng,
                    postal_Code = result[0].address_Components[5].long_name,

                };
            
        }

        public bool IsValidPhone(ICollection<PhoneNumbers> phone)
        {
            bool isValid = true;
            

            foreach (var phoneNumber in phone)
            {

                bool allDigits = true;
                bool startsWith = true;
                bool numberLenght = true;

                foreach (char c in phoneNumber.PhoneNumber)
                {
                    if (!char.IsDigit(c))
                    {
                        allDigits = false;
                        break;
                    }
                }


                    if (phoneNumber.PhoneNumber[0] != '2')
                    {
                        startsWith = false;
                    }
                          

                if (phoneNumber.PhoneNumber.Length != 8)
                {
                    numberLenght = false;
                }

                if (allDigits == true && startsWith == true && numberLenght == true)
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                } 

            }
            return isValid;

        }

        [HttpDelete]
        [Route("api/Contact/Delete/id/{id}")]
        public async Task<IHttpActionResult> DeleteByID(int id)
        {

           var result = await _contactService.RemoveContactById(id);
            if (!result)
            {
                return NotFound();
            }
            else
            {
                return Ok();
            }
        }

 



        [HttpDelete]
        [Route("api/Contact/deleteAll")]
        public async Task<bool> Clear()
        {
            await _contactService.DeleteAllContacts();
            return true;
        }


        [HttpDelete]
        [Route("api/Contact/name/{name1}")]
        public async Task<HttpResponseMessage> DeleteByName1(HttpRequestMessage request, string name1)
        {
            await _contactService.RemoveContactByName1(name1);
            return request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/Contact/surname/{surname1}")]
        public async Task<HttpResponseMessage> DeleteBySurname1(HttpRequestMessage request, string surname1)
        {
            await _contactService.RemoveContactBySurname1(surname1);
            return request.CreateResponse(HttpStatusCode.OK);
        }

        
    }
}
