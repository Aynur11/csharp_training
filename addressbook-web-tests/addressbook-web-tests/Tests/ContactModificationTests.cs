using System;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData contactData = new ContactData("Sergey", "Sergeev");
            manager.Contacts.Modify(1, contactData);
        }
    }
}
