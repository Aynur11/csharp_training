using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("some_group");
            group.Header = "some_header";
            group.Footer = "some_footer";

            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            manager.Groups.Create(group);
            List<GroupData> newGroups = manager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            manager.Groups.Create(group);
            List<GroupData> newGroups = manager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
