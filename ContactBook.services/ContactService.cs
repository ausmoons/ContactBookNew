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

        public async Task<Contact> FindContactByPhone(string phoneNumber)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).SingleOrDefaultAsync(x => x.PhoneNumbers.Any(t => t.PhoneNumber == phoneNumber));

                return contact;
            }
        }

        public async Task<Contact> FindContactByEmail(string email)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.Include(f => f.Addresses).Include(f => f.PhoneNumbers).Include(f => f.Emails).SingleOrDefaultAsync(x => x.Emails.Any(t => t.EmailAddress == email));

                return contact;
            }
        }


        public ServiceResult AddContact (Contact contact)
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

        public bool Exists(Contact contact)
        {
            using (var context = new ContactBookContext())
            {
                var exist = context.Contacts.Any(f => f.Name1 == contact.Name1 && f.Surname1 == contact.Surname1);
                                   
                return exist;
            }
        }


        public async Task RemoveContactById(int id)
        {
            using (var context = new ContactBookContext())
            {

                var contact = await context.Contacts.SingleOrDefaultAsync(f => f.Id == id);

                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    await context.SaveChangesAsync();
                }

            }
        }


        public async Task RemoveContactByName1(string name1)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.SingleOrDefaultAsync(f => f.Name1 == name1);

                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    await context.SaveChangesAsync();
                }
            }
        }


        public async Task RemoveContactBySurname1(string surname1)
        {

            using (var context = new ContactBookContext())
            {
                var contact = await context.Contacts.SingleOrDefaultAsync(f => f.Surname1 == surname1);

                if (contact != null)
                {
                    context.Contacts.Remove(contact);
                    await context.SaveChangesAsync();
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

       
        public async Task Update(Contact contact)
        {
            using (var context = new ContactBookContext())
            {

                var updateContact = await context.Contacts.FindAsync(contact.Id);
                   
                if (updateContact == null)
                {
                    return;
                }

                context.Entry(updateContact).CurrentValues.SetValues(contact);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateEmailService(ICollection<Emails> emails) //kā paņemt pareizo e-pasta id
        {
            using (var context = new ContactBookContext())
            {
                Emails updateEmailId = new Emails();                
                var updateEmail = await context.Contacts.FindAsync(updateEmailId.EmailID);

                if (updateEmail == null)
                {
                    return;
                }

                context.Entry(updateEmail).CurrentValues.SetValues(emails);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAddressService() 
        {
            using (var context = new ContactBookContext())
            {
               
            }
        }


        public async Task UpdatePhoneService()
        {
            using (var context = new ContactBookContext())
            {

            }
        }


    }
}

