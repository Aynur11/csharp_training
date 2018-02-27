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
            manager.Groups.Remove(1);
            manager.Auth.Logout();
        }
    }
}
