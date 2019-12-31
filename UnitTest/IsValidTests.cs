using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactBook.Models;
using Xunit;

namespace ContactBook.Controllers.Tests
{
    [TestClass()]
    public class IsValidTests
    {
        [TestMethod()]
        [Fact]
        public void IsValidContact_ShouldWork()
        {

            var controller = new ContactController();
            Contact contact = new Contact();
            contact.Name1 = "Jana";
            contact.Surname1 = "Saulite";
            var expected = controller.IsValid(contact);
            Assert.IsTrue(expected == true);
        }

        [TestMethod()]
        [Fact]
        public void IsValidContact_ShouldNotWork()
        {

            var controller = new ContactController();
            Contact contact = new Contact();
            contact.Name2 = "Dita";
            var expected = controller.IsValid(contact);
            Assert.IsTrue(expected == false);

        }

        [TestMethod()]
        [Fact]
        public void IsValidEmail_ShouldWork()
        {

            var controller = new ContactController();
            Emails email = new Emails();
            email.EmailAddress = "rightExample@example.com";
            var expected = controller.IsValidEmail(email);
            Assert.IsTrue(expected == true);
        }

        [TestMethod()]
        [Fact]
        public void IsValidEmail_ShouldNotWork()
        {

            var controller = new ContactController();
            Emails email = new Emails();
            email.EmailAddress = "rightExampleexample.com";
            var expected = controller.IsValidEmail(email);
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
            var controller = new ContactController();

            Addresses address = new Addresses();
            address.City = "Riga";
            address.Street = "Prusu";
            address.HouseNumber = "19";
            address.PostalCode = "LV-1057";
            var expected = controller.IsValidAddress(address);

            Assert.IsTrue(expected == true);

        }

        [TestMethod()]
        [Fact]
        public void IsValidAddress_ShouldNotWork()
        {
            var controller = new ContactController();

            Addresses address = new Addresses();
            address.City = "Riga";
            address.Street = "Prusu";
            address.HouseNumber = "19";
            address.PostalCode = "LV-0000";
            var expected = controller.IsValidAddress(address);

            Assert.IsTrue(expected == false);

        }

        [TestMethod()]
        [Fact]
        public void IsValidPhone_ShouldWork()
        {
            var controller = new ContactController();
            PhoneNumbers phoneExample = new PhoneNumbers();
            phoneExample.PhoneNumber = "27438542";
            var expected = controller.IsValidPhone(phoneExample);

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

            var expected1 = controller.IsValidPhone(phoneExample1);
            Assert.IsTrue(expected1 == false);
            var expected2 = controller.IsValidPhone(phoneExample2);
            Assert.IsTrue(expected2 == false);
            var expected3 = controller.IsValidPhone(phoneExample3);
            Assert.IsTrue(expected3 == false);
            var expected4 = controller.IsValidPhone(phoneExample4);
            Assert.IsTrue(expected4 == false);
        }
        
    }
}
