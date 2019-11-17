using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactBook.Models;
using Xunit;
using System.Collections.Generic;
using ContactBook.Data;

namespace ContactBook.Controllers.Tests
{
    [TestClass()]
    public class IsValidTests
    {
        [TestMethod()]
        [Fact]
        public void IsValidEmail_ShouldWork()
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
        public void IsValidEmail_ShouldNotWork()
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
        public void IsValidDate_ShouldWork()
        {
            var controller = new ContactController();

            Contact contact = new Contact();
            contact.Birthday = new System.DateTime(2008, 5, 1);
            var expected = controller.IsValidDate(contact.Birthday);

            Assert.IsTrue(expected == true);

        }

        [TestMethod()]
        [Fact]
        public void IsValidDate_ShouldNotWork()
        {

            var controller = new ContactController();

            Contact contact = new Contact();
            contact.Birthday = new System.DateTime(2028, 5, 1);
            var expected = controller.IsValidDate(contact.Birthday);

            Assert.IsTrue(expected == false);

        }

        [TestMethod()]
        [Fact]
        public void IsValidAddress_ShouldWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void IsValidAddress_ShouldNotWork()
        {



        }

        [TestMethod()]
        [Fact]
        public void IsValidPhone_ShouldWork()
        {
            var controller = new ContactController();

            PhoneNumbers phoneExample = new PhoneNumbers();

            phoneExample.PhoneNumber = "27438542";


            List<PhoneNumbers> newPhoneList = new List<PhoneNumbers>();

            newPhoneList.Add(phoneExample);
           

            var expected = controller.IsValidPhone(newPhoneList);

            Assert.IsTrue(expected == true);


        }

        [TestMethod()]
        [Fact]
        public void IsValidPhone_ShouldNotWork()
        {
            var controller = new ContactController();

            PhoneNumbers phoneExample1 = new PhoneNumbers();
            PhoneNumbers phoneExample2 = new PhoneNumbers();
            PhoneNumbers phoneExample3 = new PhoneNumbers();
            PhoneNumbers phoneExample4 = new PhoneNumbers();

            phoneExample1.PhoneNumber = "2743852";
            phoneExample2.PhoneNumber = "27l38542";
            phoneExample3.PhoneNumber = "77438542";
            phoneExample4.PhoneNumber = "274f852";


            List<PhoneNumbers> newPhoneList = new List<PhoneNumbers>();

            newPhoneList.Add(phoneExample1);
            newPhoneList.Add(phoneExample2);
            newPhoneList.Add(phoneExample3);
            newPhoneList.Add(phoneExample4);


            var expected = controller.IsValidPhone(newPhoneList);

            Assert.IsTrue(expected == false);


        }

        [TestMethod()]
        [Fact]
        public void IsValidPhone1_ShouldNotWork()
        {
            var controller = new ContactController();

            PhoneNumbers phoneExample1 = new PhoneNumbers();
            

            phoneExample1.PhoneNumber = "2743852";
           


            List<PhoneNumbers> newPhoneList = new List<PhoneNumbers>();

            newPhoneList.Add(phoneExample1);
           


            var expected = controller.IsValidPhone(newPhoneList);

            Assert.IsTrue(expected == false);


        }

        [TestMethod()]
        [Fact]
        public void IsValidPhone2_ShouldNotWork()
        {
            var controller = new ContactController();

           
            PhoneNumbers phoneExample2 = new PhoneNumbers();
            
            phoneExample2.PhoneNumber = "27l38542";
            

            List<PhoneNumbers> newPhoneList = new List<PhoneNumbers>();

           
            newPhoneList.Add(phoneExample2);
            


            var expected = controller.IsValidPhone(newPhoneList);

            Assert.IsTrue(expected == false);

        }

        [TestMethod()]
        [Fact]
        public void IsValidPhone3_ShouldNotWork()
        {
            var controller = new ContactController();

            
            PhoneNumbers phoneExample3 = new PhoneNumbers();
           
            phoneExample3.PhoneNumber = "77438542";
            


            List<PhoneNumbers> newPhoneList = new List<PhoneNumbers>();

           
            newPhoneList.Add(phoneExample3);
            

            var expected = controller.IsValidPhone(newPhoneList);

            Assert.IsTrue(expected == false);


        }
        [TestMethod()]
        [Fact]
        public void IsValidPhone4_ShouldNotWork()
        {
            var controller = new ContactController();

     
            PhoneNumbers phoneExample4 = new PhoneNumbers();

            phoneExample4.PhoneNumber = "274f852";


            List<PhoneNumbers> newPhoneList = new List<PhoneNumbers>();


            newPhoneList.Add(phoneExample4);


            var expected = controller.IsValidPhone(newPhoneList);

            Assert.IsTrue(expected == false);


        }

    }
}
