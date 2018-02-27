using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            
            manager.Navigator.GoToHomePage();
            manager.Auth.Login();
            GroupData group = new GroupData("some_group");
            group.Header = "some_header";
            group.Footer = "some_footer";
            manager.Groups.Create(group);
            manager.Auth.Logout();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            manager.Navigator.GoToHomePage();
            manager.Auth.Login();
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            manager.Groups.Create(group);
            manager.Auth.Logout();
        }
    }
}
