using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            List<ContactData> oldContacts = manager.Contacts.GetContactsList();
            ContactData contactData = new ContactData("Ivan", "Ivanov");
            manager.Contacts.Modify(1, contactData);
            List<ContactData> newContacts = manager.Contacts.GetContactsList();
            Assert.AreEqual(oldContacts.Count, newContacts.Count);
        }
    }
}
