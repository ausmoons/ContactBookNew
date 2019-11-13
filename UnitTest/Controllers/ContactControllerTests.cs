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
        public void IsValidEmailTest_ShouldWork()
        {

            var controller = new ContactController();

            Emails emailExample1 = new Emails();
            Emails emailExample2 = new Emails();


            emailExample1.EmailAddress = "rightExample@example.com";
            emailExample2.EmailAddress = "me@me.lv";

            List<Emails> newEmailList = new List<Emails>();

            newEmailList.Add(emailExample1);
            newEmailList.Add(emailExample2);


            var expected = controller.IsValidEmail(newEmailList);

            Assert.IsTrue(expected == true);


        }

        [TestMethod()]
        [Fact]
        public void IsValidEmailTest_ShouldNotWork()
        {

            var controller = new ContactController();

            Emails emailExample1 = new Emails();
            Emails emailExample2 = new Emails();


            emailExample1.EmailAddress = "rightExampleexample.com";
            emailExample2.EmailAddress = "me@melv";

            List<Emails> newEmailList = new List<Emails>();

            newEmailList.Add(emailExample1);
            newEmailList.Add(emailExample2);


            var expected = controller.IsValidEmail(newEmailList);

            Assert.IsTrue(expected == false);

        }


        [TestMethod()]
        [Fact]
        public void AddContact_ShouldAdd()
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
        public void AddContact_ShouldNotAdd()
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
        public void UpdateContact_ShouldUpdate()
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
        public void UpdateContact_ShouldNotUpdate()
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

    }
}