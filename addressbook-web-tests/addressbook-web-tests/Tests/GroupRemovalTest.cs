using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            manager.Groups.CreateGroupIfNotExists(1);
        }   
        [Test]
        public void GroupRemovalTest()
        {
            //List<GroupData> oldGroups = manager.Groups.GetGroupList();
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[0];
            manager.Groups.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, manager.Groups.GetGroupCount());

            //List<GroupData> newGroups = manager.Groups.GetGroupList();
            List<GroupData> newGroups = GroupData.GetAll();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
