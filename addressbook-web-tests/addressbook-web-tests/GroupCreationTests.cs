﻿using System;
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
            Authorization authorization = new Authorization(driver, new AccountData("admin", "secret"));
            GoToHomePage();
            authorization.Login();
            GoToGroupsPage();
            InitGrouptCreation();
            GroupData group = new GroupData("some_group");
            group.Header = "some_header";
            group.Footer = "some_footer";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            authorization.Logout();
        }
    }
}
