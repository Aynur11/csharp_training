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
            GroupData group = new GroupData("zGsome_group");
            group.Header = "some_header";
            group.Footer = "some_footer";

            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            manager.Groups.Create(group);
            
            Assert.AreEqual(oldGroups.Count + 1, manager.Groups.GetGroupCount());

            List<GroupData> newGroups = manager.Groups.GetGroupList();
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            manager.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, manager.Groups.GetGroupCount());

            List<GroupData> newGroups = manager.Groups.GetGroupList();
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            manager.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, manager.Groups.GetGroupCount());

            List<GroupData> newGroups = manager.Groups.GetGroupList();
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
