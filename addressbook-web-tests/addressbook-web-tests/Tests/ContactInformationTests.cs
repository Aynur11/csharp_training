﻿using System;
using System.Text;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
            ContactData fromTable = manager.Contacts.GetContactInformationFromTable(1);
            ContactData fromForm = manager.Contacts.GetContactInformationFromEditForm(1);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void ContactDetailsComplianceTest()
        {
            ContactData fromForm = manager.Contacts.GetContactInformationFromEditForm(1);
            string fromDetails = manager.Contacts.GetContactInformationFromDetails(1);
            string sFromForm = manager.Contacts.ConvertContactDataToString(fromForm);
            Assert.AreEqual(fromDetails, sFromForm);

        }
    }
}
