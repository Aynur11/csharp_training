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
            manager.Navigator.GoToHomePage();
            manager.Auth.Login();
            manager.Contacts
                .InitNewContact()
                .FillContact(entryData);
            manager.Navigator.GoToHomePage();
            manager.Auth.Logout();
        }
    }
}
