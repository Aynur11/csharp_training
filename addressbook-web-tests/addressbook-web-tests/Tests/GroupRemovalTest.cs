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
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = manager.Groups.GetGroupList();
            if (oldGroups.Count != 0)
            {
                manager.Groups.Remove(1);

                List<GroupData> newGroups = manager.Groups.GetGroupList();
                oldGroups.RemoveAt(0);
                Assert.AreEqual(oldGroups, newGroups);
            }
        }
    }
}
