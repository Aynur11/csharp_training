using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {

        [SetUp]
        public void BeforeTest()
        {
            manager.Contacts.AddContactToGroupIfNotIncludedInGroup();
        }

        [Test]
        public void RemovingContactFromGroupTest()
        {
            ContactData contact = ContactData.GetAll()[0];
            List<GroupData> OldConsistGroup = GroupData.GetContactGroupName(contact);
            manager.Contacts.RemoveContactFromGroup(contact);

            List<GroupData> NewConsistGroup = GroupData.GetContactGroupName(contact);

            Assert.AreEqual(OldConsistGroup.Count - 1, NewConsistGroup.Count);
        }
    }
}