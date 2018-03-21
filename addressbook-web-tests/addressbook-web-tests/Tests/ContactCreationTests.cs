using System;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{

    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    Address = GenerateRandomString(100),
                    HomePhone = GenerateRandomString(100),
                    MobilePhone = GenerateRandomString(100),
                    WorkPhone = GenerateRandomString(100),
                    Email = GenerateRandomString(100),
                    //Email2 = GenerateRandomString(100),
                    //Email3 = GenerateRandomString(100)
                });
            }
            return contacts;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = manager.Contacts.GetContactsList();
            //ContactData entryData = new ContactData("gIvan", "glumDIvanov");
            manager.Contacts.Create(contact);
            List<ContactData> newContacts = manager.Contacts.GetContactsList();

            Assert.AreEqual(oldContacts.Count + 1, manager.Contacts.GetContactCount());

            oldContacts.Add(contact);
          
            oldContacts.Sort();
            newContacts.Sort();
            
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
