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
using Newtonsoft.Json;

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
        [Route("api/Contact/email/{emailID}")]
        public async Task<HttpResponseMessage> GetEmail(HttpRequestMessage request, int emailID)
        {
            var email = await _contactService.FindEmailByEmailID(emailID);
            if (email == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, email);
            }

            return request.CreateResponse(HttpStatusCode.OK, email);
        }

        [HttpGet]
        [Route("api/Contact/phone/{phoneNumberID}")]
        public async Task<HttpResponseMessage> GetByPhoneNmber(HttpRequestMessage request, int phoneNumberID)
        {
            var phone = await _contactService.FindContactByPhone(phoneNumberID);
            if (phone == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, phone);
            }

            return request.CreateResponse(HttpStatusCode.OK, phone);
        }

        [HttpGet]
        [Route("api/Contact/address/{addressID}")]
        public async Task<HttpResponseMessage> GetByAddress(HttpRequestMessage request, int addressID)
        {
            var address = await _contactService.FindContactByAddress(addressID);
            if (address == null)
            {
                return request.CreateResponse(HttpStatusCode.NotFound, address);
            }

            return request.CreateResponse(HttpStatusCode.OK, address);
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


        [HttpPost]
        [Route("api/Email/{ContactId}")]
        public IHttpActionResult AddEmail(Emails email)
        {
            if (!IsValidEmail(email))
            {
                return BadRequest();
            }

            var result = _contactService.AddEmailService(email);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            email.EmailID = result.Id;
            return Created(string.Empty, email);

        }

        [HttpPost]
        [Route("api/Phone/{ContactId}")]
        public IHttpActionResult AddPhone(PhoneNumbers phone)
        {
            if (!IsValidPhone(phone))
            {
                return BadRequest();
            }

            var result = _contactService.AddPhoneService(phone);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            phone.PhoneNumberID = result.Id;
            return Created(string.Empty, phone);

        }

        [HttpPost]
        [Route("api/Address/{ContactId}")]
        public IHttpActionResult AddAddress(Addresses address)
        {
            if (!IsValidAddress(address))
            {
                return BadRequest();
            }

            var result = _contactService.AddAddressService(address);
            if (!result.Succeeded)
            {
                return Conflict();
            }
            address.AddressID = result.Id;
            return Created(string.Empty, address);

        }

        [HttpPut]
        [Route("api/Contact/update/id/{id}")]
        public IHttpActionResult UpdateContact(int id, Contact updContact)
        {

            var contactToUpdate = _contactService.FindContactById(id);

            if (contactToUpdate == null)
            {
                return BadRequest();
            }
            else
            {
                var result = _contactService.Update(id, updContact);
                if (!result.Succeeded)
                {
                    return Conflict();
                }
                updContact.Id = result.Id;
                return Created(string.Empty, updContact);
            }
            
            

        }

        [HttpPut]
        [Route("api/Contact/update/email/{emailID}")]
        public IHttpActionResult UpdateEmail(int EmailID, Emails updEmail)
        {
            if (!IsValidEmail(updEmail))
            {
                return BadRequest();
            }

            var result = _contactService.UpdateEmailService(EmailID, updEmail);
            return Created(string.Empty, updEmail);

        }

        [HttpPut]
        [Route("api/Contact/update/address/{addressID}")]
        public IHttpActionResult UpdateAddress(int addressID, Addresses updAddress)
        {
            if (!IsValidAddress(updAddress))
            {
                return BadRequest();
            }

            var result = _contactService.UpdateAddressService(addressID, updAddress);
            return Created(string.Empty, updAddress);

        }

        [HttpPut]
        [Route("api/Contact/update/phone/{phoneNumberID}")]
        public IHttpActionResult UpdatePhone(int phoneNumberID, PhoneNumbers updPhoneNumber)
        {
            if (!IsValidPhone(updPhoneNumber))
            {
                return BadRequest();
            }

            var result = _contactService.UpdatePhoneService(phoneNumberID, updPhoneNumber);
            return Created(string.Empty, updPhoneNumber);

        }


        public bool IsValid(Contact contact)
        {
            return !string.IsNullOrEmpty(contact.Name1) &&
                     !string.IsNullOrEmpty(contact.Surname1) && IsValidDate(contact.Birthday);
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

        public bool IsValidEmail(Emails email)
        {

            return new EmailAddressAttribute().IsValid(email.EmailAddress);
        }

        public  bool IsValidAddress(Addresses addresses) 
        {
            var street = addresses.Street;
            var houseNumber = addresses.HouseNumber;
            var city = addresses.City;
            var postalCode = addresses.PostalCode;
            bool isValid = true;


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

        public bool IsValidPhone(PhoneNumbers phoneNumber)
        {
            bool isValid = true;

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
        [Route("api/Contact/Delete/emailID/{emailID}")]
        public async Task<IHttpActionResult> DeleteByEmailID(int emailID)
        {

            var result = await _contactService.RemoveContactByEmailID(emailID);
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
        [Route("api/Contact/Delete/addressID/{addressID}")]
        public async Task<IHttpActionResult> DeleteByAddressID(int addressID)
        {

            var result = await _contactService.RemoveContactByAddressID(addressID);
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
        [Route("api/Contact/Delete/phoneID/{phoneID}")]
        public async Task<IHttpActionResult> DeleteByPhoneID(int phoneID)
        {

            var result = await _contactService.RemoveContactByPhoneID(phoneID);
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


  

        
    }
}
