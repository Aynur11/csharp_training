using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{

    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData entryData = new ContactData("Ivan", "Ivanov");
            manager.Contacts.InitNewContact();
            manager.Contacts.FillContact(entryData);
            manager.Navigator.GoToHomePage();
            manager.Auth.Logout();
        }
    }
}
