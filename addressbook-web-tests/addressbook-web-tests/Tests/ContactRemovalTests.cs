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
            manager.Contacts.CreateContactIfNotExists(2);
        }

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData toBeRemoved = oldContacts[1];
            manager.Contacts.Remove(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, manager.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            
            oldContacts.RemoveAt(1);
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }
    }
}