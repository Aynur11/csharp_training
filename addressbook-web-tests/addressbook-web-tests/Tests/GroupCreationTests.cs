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
            manager.Navigator.GoToGroupsPage();
            manager.Groups.InitGrouptCreation();
            GroupData group = new GroupData("some_group");
            group.Header = "some_header";
            group.Footer = "some_footer";
            manager.Groups
                .FillGroupForm(group)
                .SubmitGroupCreation()
                .ReturnToGroupsPage();
            manager.Auth.Logout();
        }
    }
}
