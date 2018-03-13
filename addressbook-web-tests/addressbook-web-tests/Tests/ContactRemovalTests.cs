using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = manager.Contacts.GetContactsList();
            if (oldContacts.Count != 0)
            {
                manager.Contacts.Remove(3);
                List<ContactData> newContacts = manager.Contacts.GetContactsList();
                oldContacts.RemoveAt(2);
                //foreach(ContactData contact in oldContacts)
                //{
                //    Console.WriteLine("{0}, {1}", contact.Firstname, contact.Lastname);
                //}
                Assert.AreEqual(oldContacts, newContacts);
            }
        }
    }
}