using System;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactData = new ContactData("Ivan", "Ivanov");
            manager.Contacts.Modify(5, contactData);
        }
    }
}
