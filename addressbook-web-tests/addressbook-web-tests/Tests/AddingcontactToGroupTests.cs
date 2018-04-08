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
        [SetUp]
        public void BeforeTest()
        {
            manager.Groups.CreateGroupIfNotExists(6 + 1);
            manager.Contacts.CreateContactIfNotExists(1);
            manager.Contacts.IfContactWithoutGroupsCreateNew(6);
        }

        [Test]
        public void AddingContactToGroupTest()
        {
            GroupData group = GroupData.GetAll()[6];
            List<ContactData> oldList = group.GetContacts();


            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();
            manager.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
