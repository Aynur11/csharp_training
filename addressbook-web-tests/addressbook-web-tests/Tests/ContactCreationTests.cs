using System;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{

    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            List<ContactData> oldContacts = manager.Contacts.GetContactsList();
            ContactData entryData = new ContactData("Ivan", "Ivanov");
            manager.Contacts.Create(entryData);
            List<ContactData> newContacts = manager.Contacts.GetContactsList();
            oldContacts.Add(entryData);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
