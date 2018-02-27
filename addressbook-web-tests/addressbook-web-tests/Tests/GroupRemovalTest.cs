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
            manager.Navigator.GoToHomePage();
            manager.Auth.Login();
            manager.Navigator.GoToGroupsPage();
            manager.Groups.SelectGroup(1);
            manager.Groups.RemoveGroup(1);
            manager.Groups.ReturnToGroupsPage();
            manager.Auth.Logout();
        }
    }
}
