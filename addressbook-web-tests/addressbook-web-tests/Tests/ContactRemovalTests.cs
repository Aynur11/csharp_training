using System;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            manager.Contacts.Remove(3);
        }
    }
}