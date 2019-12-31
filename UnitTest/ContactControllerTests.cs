using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactBook.Models;
using Xunit;
using System.Collections.Generic;
using ContactBook.Data;

namespace ContactBook.Controllers.Tests
{
    [TestClass()]
    public class ContactControllerTests
    {


        [TestMethod()]
        [Fact]
        public void AddContact_ShouldWork()
        {           
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            contact.Company = "MyComnapy";          
            ContactService _contactService = new ContactService();                
            controller.AddContact(contact);
            Assert.IsTrue(_contactService.Exists(contact));
           
        }

        [TestMethod()]
        [Fact]
        public void AddContact_ShouldNotWork()
        {
            var controller = new ContactController();
           controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            ContactService _contactService = new ContactService();
            controller.AddContact(contact);
            Assert.IsFalse(_contactService.Exists(contact));
        }


        [TestMethod()]
        [Fact]
        public void AddEmail_ShouldWork()
        {
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            ContactService _contactService = new ContactService();
            controller.AddContact(contact);

            Emails email = new Emails();
            email.EmailAddress = "email@gmail.com";
            email.Type = "home";
            email.ContactId = contact.Id;
            _contactService.AddEmailService(email);
            controller.AddEmail(email);
            Assert.IsTrue(_contactService.ExistsEmail(email));

        }

        [TestMethod()]
        [Fact]
        public  void AddEmail_ShouldNotWork()
        {
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            ContactService _contactService = new ContactService();
            controller.AddContact(contact);

            Emails email = new Emails();
            email.EmailAddress = "emailgmailcom";
            email.Type = "home";
            email.EmailID = contact.Id;
            controller.AddEmail(email);
            Assert.IsFalse(_contactService.ExistsEmail(email));


        }



           [TestMethod()]
           [Fact]
           public void UpdateContact_ShouldWork()
           {

            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            contact.Company = "MyComnapy";
            ContactService _contactService = new ContactService();
            controller.AddContact(contact);
            Assert.IsTrue(_contactService.Exists(contact));

            Assert.IsTrue(contact.Name2 == null);

            contact.Name2 = "Updating Name2";

            controller.UpdateContact(contact.Id, contact);
            Assert.IsTrue(contact.Name2 == "Updating Name2");

           }

           [TestMethod()]
           [Fact]
           public void UpdateContact_ShouldNotWork()
           {
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            contact.Company = "MyComnapy";
            ContactService _contactService = new ContactService();
            controller.AddContact(contact);
            Assert.IsTrue(_contactService.Exists(contact));

         
            contact.Name1 = null;

            _contactService.Update(contact.Id, contact);


            
        }

           [TestMethod()]
           [Fact]
           public void UpdateEmail_ShouldWork()
           {
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            ContactService _contactService = new ContactService();
            controller.AddContact(contact);

            Emails email = new Emails();
            email.EmailAddress = "email@gmail.com";
            email.Type = "home";
            email.ContactId = contact.Id;
            _contactService.AddEmailService(email);
            controller.AddEmail(email);
            email.Type = "work";
            controller.UpdateEmail(email.EmailID, email);
            Assert.IsTrue(email.Type == "work");

            }

           [TestMethod()]
           [Fact]
           public void UpdateEmail_ShouldNotWork()
           {
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            ContactService _contactService = new ContactService();
            controller.AddContact(contact);

            Emails email = new Emails();
            email.EmailAddress = "email@gmail.com";
            email.Type = "home";
            email.ContactId = contact.Id;
            _contactService.AddEmailService(email);
            controller.AddEmail(email);
            email.EmailAddress = "emailgmailcom";
            controller.UpdateEmail(email.EmailID, email);
            Assert.IsFalse(email.EmailAddress == "emailgmailcom");


        }

           [TestMethod()]
           [Fact]
           public void UpdateAddress_ShouldWork()
           {


           }

           [TestMethod()]
           [Fact]
           public void UpdateAddress_ShouldNotWork()
           {



           }

           [TestMethod()]
           [Fact]
           public void UpdatePhone_ShouldWork()
           {


           }

           [TestMethod()]
           [Fact]
           public void UpdatePhone_ShouldNotWork()
           {



           }

           [TestMethod()]
           [Fact]
           public void DeleteByName1_ShouldWork()
           {


           }

           [TestMethod()]
           [Fact]
           public void DeleteByName1_ShouldNotWork()
           {



           }

           [TestMethod()]
           [Fact]
           public void Clear_ShouldWork()
           {


           }

           [TestMethod()]
           [Fact]
           public void Clear_ShouldNotWork()
           {



           }
          

    }
}