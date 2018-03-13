using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModoficationTest()
        {
            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            GroupData newData = new GroupData("modifiedname");
            newData.Header = null;
            newData.Footer = "modFooter";
            manager.Groups.Modify(4, newData);
            List<GroupData> newGroups = manager.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
        }
    }
}