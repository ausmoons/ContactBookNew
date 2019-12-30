using ContactBook.Data;
using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;



namespace ContactBook
{
    public class ContactService
    {

        

        public async Task<ICollection<Contact>> FindAllContacts()
        {
            using (var context = new ContactBookContext())
            {
                return await context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).ToListAsync();
            }
        }       

        public async Task<Contact> FindContactById(int id)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).SingleOrDefaultAsync(x => x.Id == id);
               

                return contact;
            }
        }

        public async Task<Emails> FindEmailByEmailID(int emailID)
        {

            using (var context = new ContactBookContext())
            {
                var email = await context.Emails.SingleOrDefaultAsync(x => x.EmailID == emailID);

                return email;
            }
        }

        public async Task<PhoneNumbers> FindContactByPhone(int phoneNumberID)
        {

            using (var context = new ContactBookContext())
            {
                var phone = await context.PhoneNumbers.SingleOrDefaultAsync(x => x.PhoneNumberID == phoneNumberID);

                return phone;
            }
        }

        public async Task<Addresses> FindContactByAddress(int addressID)
        {

            using (var context = new ContactBookContext())
            {
                var address = await context.Addresses.SingleOrDefaultAsync(x => x.AddressID == addressID);

                return address;
            }
        }

        public async Task<Contact> FindContactByName1(string name1)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).SingleOrDefaultAsync(x => x.Name1 == name1);

                return contact;
            }
        }

      

        public async Task<Contact> FindContactBySurname1(string surname1)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).SingleOrDefaultAsync(x => x.Surname1 == surname1);

                return contact;
            }
        }

        public async Task<Contact> FindContactByCompany(string company)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).SingleOrDefaultAsync(x => x.Company == company);

                return contact;
            }
        }


        public ServiceResult AddContact(Contact contact)
        {
            using (var context = new ContactBookContext())
            {
                if (Exists(contact))
                {
                    return new ServiceResult(false);
                }
                else
                {
                    contact = context.Contacts.Add(contact);
                    context.SaveChanges();
                    return new ServiceResult(contact.Id, true);
                }
            }
        }

        public ServiceResult AddEmailService(Emails email)
        {
            using (var context = new ContactBookContext())
            {
                if (ExistsEmail(email))
                {
                    return new ServiceResult(false);
                }
                else
                {
                    email = context.Emails.Add(email);
                    context.SaveChanges();
                    return new ServiceResult(email.EmailID, true);
                }
            }
        }

        public ServiceResult AddPhoneService(PhoneNumbers phone)
        {
            using (var context = new ContactBookContext())
            {
                if (ExistsPhone(phone))
                {
                    return new ServiceResult(false);
                }
                else
                {
                    phone = context.PhoneNumbers.Add(phone);
                    context.SaveChanges();
                    return new ServiceResult(phone.PhoneNumberID, true);
                }
            }
        }

        public ServiceResult AddAddressService(Addresses address)
        {
            using (var context = new ContactBookContext())
            {
                if (ExistsAddress(address))
                {
                    return new ServiceResult(false);
                }
                else
                {
                    address = context.Addresses.Add(address);
                    context.SaveChanges();
                    return new ServiceResult(address.AddressID, true);
                }
            }
        }



        public ServiceResult Update(int id, Contact updContact)
        {
            using (var context = new ContactBookContext())
            {
                var updateContact =  context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).SingleOrDefault(x => x.Id == id);
                context.Entry(updateContact).CurrentValues.SetValues(updContact);
                context.SaveChanges();
                return new ServiceResult(id, true);
                

               
            }
        }

        public ServiceResult UpdateEmailService(int emailID, Emails updEmail)
        {
            using (var context = new ContactBookContext())
            {

                var updateEmail = context.Emails.SingleOrDefault(x => x.EmailID == emailID); 
                context.Entry(updateEmail).CurrentValues.SetValues(updEmail);
                context.SaveChanges();
                return new ServiceResult(emailID, true);
            }
        }

        public ServiceResult UpdateAddressService(int addressID, Addresses address)
        {
            using (var context = new ContactBookContext())
            {

                var updateAddress = context.Addresses.SingleOrDefault(x => x.AddressID == addressID);
                context.Entry(updateAddress).CurrentValues.SetValues(address);
                context.SaveChanges();
                return new ServiceResult(addressID, true);
            }
        }


        public ServiceResult UpdatePhoneService(int phoneNumberID, PhoneNumbers phoneNumber)
        { 
            using (var context = new ContactBookContext())
            {

                var updatephoneNumber = context.PhoneNumbers.SingleOrDefault(x => x.PhoneNumberID == phoneNumberID);
                context.Entry(updatephoneNumber).CurrentValues.SetValues(phoneNumber);
                context.SaveChanges();
                return new ServiceResult(phoneNumberID, true);
            }
        }

        public bool Exists(Contact contact)
        {
            using (var context = new ContactBookContext())
            {
                var exist = context.Contacts.Any(f => f.Name1 == contact.Name1 && f.Surname1 == contact.Surname1);
                                   
                return exist;
            }
        }

        public bool ExistsEmail(Emails email)
        {
            using (var context = new ContactBookContext())
            {
                var exist = context.Emails.Any(f => f.EmailAddress == email.EmailAddress);

                return exist;
            }
        }

        public bool ExistsPhone(PhoneNumbers phone)
        {
            using (var context = new ContactBookContext())
            {
                var exist = context.PhoneNumbers.Any(f => f.PhoneNumber == phone.PhoneNumber);

                return exist;
            }
        }

        public bool ExistsAddress(Addresses address)
        {
            using (var context = new ContactBookContext())
            {
                var exist = context.Addresses.Any(f => f.City == address.City && f.Street == address.Street && f.HouseNumber == address.HouseNumber);

                return exist;
            }
        }

        public async Task<bool> RemoveContactById(int id)
        {
            using (var context = new ContactBookContext())
            {

                var contact = await context.Contacts.SingleOrDefaultAsync(f => f.Id == id);

                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    await context.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }
    

            }
        }

        public async Task<bool> RemoveContactByEmailID(int emailID)
        {
            using (var context = new ContactBookContext())
            {

                var email = await context.Emails.SingleOrDefaultAsync(f => f.EmailID == emailID);

                if (email != null)
                {
                    context.Emails.Remove(email);
                    await context.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }


            }
        }


        public async Task<bool> RemoveContactByAddressID(int addressID)
        {
            using (var context = new ContactBookContext())
            {

                var address = await context.Addresses.SingleOrDefaultAsync(f => f.AddressID == addressID);

                if (address != null)
                {
                    context.Addresses.Remove(address);
                    await context.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }


            }
        }

        public async Task<bool> RemoveContactByPhoneID(int phoneID)
        {
            using (var context = new ContactBookContext())
            {

                var phone = await context.PhoneNumbers.SingleOrDefaultAsync(f => f.PhoneNumberID == phoneID);

                if (phone != null)
                {
                    context.PhoneNumbers.Remove(phone);
                    await context.SaveChangesAsync();
                    return true;

                }
                else
                {
                    return false;
                }


            }
        }




        public async Task DeleteAllContacts()
        {
            using (var context = new ContactBookContext())
            {
                context.Contacts.RemoveRange(context.Contacts);
                await context.SaveChangesAsync();
            }
        }







    }
}

