using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [SetUp]
        public void BeforeTest()
        {
            manager.Groups.CreateGroupIfNotExists(1);
        }
        
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("modifiedname");
            newData.Header = null;
            newData.Footer = "modFooter";

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];
            manager.Groups.Modify(oldData, newData);

            Assert.AreEqual(oldGroups.Count, manager.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);

            foreach(GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}