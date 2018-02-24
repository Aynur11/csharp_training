using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            Authorization authorization = new Authorization(driver, new AccountData("admin", "secret"));
            GoToHomePage();
            authorization.Login();
            GoToGroupsPage();
            SelectGroup();
            RemoveGroup();
            ReturnToGroupsPage();
            authorization.Logout();
        }
    }
}
