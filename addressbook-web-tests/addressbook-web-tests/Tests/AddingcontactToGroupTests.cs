using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
namespace addressbook_web_tests
{
    public class ChangeContactInGroupTests : AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            manager.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void RemovingContactFromGroupTest()
        {
            ContactData contact = ContactData.GetAll()[0];
            List<GroupData> OldConsistGroup = GroupData.GetContactGroupName(contact);
            manager.Contacts.RemoveContactFromGroup(contact);

            List<GroupData> NewConsistroup = GroupData.GetContactGroupName(contact);

            Assert.AreEqual(OldConsistGroup.Count - 1, NewConsistroup.Count);
        }
    }
}
