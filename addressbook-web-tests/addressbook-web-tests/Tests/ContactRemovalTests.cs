using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            manager.Navigator.GoToHomePage();
            while (!manager.Contacts.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + 2 + "]")))
                manager.Contacts.Create(new ContactData("NewFirstname", "NewLastname"));
        }
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = manager.Contacts.GetContactsList();
            manager.Contacts.Remove(2);

            Assert.AreEqual(oldContacts.Count - 1, manager.Contacts.GetContactCount());

            List<ContactData> newContacts = manager.Contacts.GetContactsList();
            oldContacts.RemoveAt(1);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}