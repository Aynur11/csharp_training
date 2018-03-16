using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            manager.Groups.CreateGroupIfNotExists(1);
        }
        
        [Test]
        public void GroupModoficationTest()
        {
            GroupData newData = new GroupData("modifiedname");
            newData.Header = null;
            newData.Footer = "modFooter";

            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            manager.Groups.Modify(1, newData);

            Assert.AreEqual(oldGroups.Count, manager.Groups.GetGroupCount());

            List<GroupData> newGroups = manager.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}