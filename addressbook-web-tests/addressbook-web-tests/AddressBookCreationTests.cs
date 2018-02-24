using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{

    [TestFixture]
    public class AddressBookCreationTests : TestBase
    {
        [Test]
        public void AddressBookCreationTest()
        {
            Authorization authorization = new Authorization(driver, new AccountData("admin", "secret"));
            AddressBookEntryData entryData = new AddressBookEntryData("Ivan", "Ivanov");
            GoToHomePage();
            authorization.Login();
            InitNewEntry();
            FillEntry(entryData);
            GoToHomePage();
            authorization.Logout();
        }
    }
}
