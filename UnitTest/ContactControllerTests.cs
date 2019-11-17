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
            contact.Id = 63;
            contact.Name1 = "Ilze";
            contact.Surname1 = "Berzina";
            contact.Company = "MyComnapy";          


            bool expected = controller.IsValid(contact);
            Assert.IsTrue(expected == true);
            ContactService _contactService = new ContactService();

            var result = _contactService.AddContact(contact);
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(_contactService.Exists(contact));
           
        }

        [TestMethod()]
        [Fact]
        public void AddContact_ShouldNotWork()
        {
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Id = 36;
            contact.Name1 = "Daina";
            contact.Company = "MyComnapy";
            contact.Notes = "Adding name and company";


            bool expected = controller.IsValid(contact);
            Assert.IsFalse(expected == true);
            ContactService _contactService = new ContactService();

            var result = _contactService.AddContact(contact); //nevar pievienot, tāpēc parāda exception pie context.SaveChanges();
            Assert.IsFalse(result.Succeeded);
            Assert.IsFalse(_contactService.Exists(contact));
        }


        [TestMethod()]
        [Fact]
        public void GetByName1_ShouldWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void GetByName1_ShouldNotWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void GetBySurname1_ShouldWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void GetBySurname1_ShouldNotWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void GetByEmail_ShouldWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void GetByEmail_ShouldNotWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void GetAllContacts_ShouldWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void GetAllContacts_ShouldNotWork()
        {



        }




        [TestMethod()]
        [Fact]
        public void UpdateContact_ShouldWork()
        {
          
            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Id = 96;
            contact.Name1 = "Anna";
            contact.Surname1 = "Liepa";
            contact.Company = "Visur";
            contact.Notes = "Adding name and company";


            bool expected = controller.IsValid(contact);
            Assert.IsTrue(expected == true);
            ContactService _contactService = new ContactService();

            var result = _contactService.AddContact(contact);
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(contact.Name2 == null);

            contact.Name2 = "Updating Name2";

            var updatesContact = controller.UpdateContact(contact); //jāpārveido, lai notestē ar name2
            Assert.IsTrue(contact.Name2 == "Updating Name2");

        }

        [TestMethod()]
        [Fact]
        public void UpdateContact_ShouldNotWork()
        {

            var controller = new ContactController();
            controller.Clear();
            Contact contact = new Contact();
            contact.Id = 96;
            contact.Name1 = "Daina";
            contact.Surname1 = "Liepa";
            contact.Company = "Visur";
            contact.Notes = "Adding name and company";


            bool expected = controller.IsValid(contact);
            Assert.IsTrue(expected == true);
            ContactService _contactService = new ContactService();

            var result = _contactService.AddContact(contact);
            Assert.IsTrue(result.Succeeded);
            Assert.IsTrue(contact.Name2 == null);

            contact.Name1 = "";
            bool expectedUpdates = controller.IsValid(contact);
            Assert.IsFalse(expectedUpdates == true);
            var updatesContact = controller.UpdateContact(contact);            
            Assert.IsTrue(contact.Name1 != null);

        }

        [TestMethod()]
        [Fact]
        public void UpdateEmail_ShouldWork()
        {

            
        }

        [TestMethod()]
        [Fact]
        public void UpdateEmail_ShouldNotWork()
        {

            

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