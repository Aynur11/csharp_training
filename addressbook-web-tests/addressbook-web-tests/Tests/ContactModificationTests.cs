using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            manager.Contacts.CreateContactIfNotExists(1);
        }

        [Test]
        public void ContactModificationTest()
        {
            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[4];
            ContactData contactData = new ContactData("bTest", "bTestov");
            manager.Contacts.Modify(oldData, contactData);

            Assert.AreEqual(oldContacts.Count, manager.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Lastname = contactData.Lastname;
            oldContacts[0].Firstname = contactData.Firstname;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(contactData.Lastname, contact.Lastname);
                    Assert.AreEqual(contactData.Firstname, contact.Firstname);

                }
            }
        }
    }
}
