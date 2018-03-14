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
        [SetUp]
        public void BeforeTest()
        {
            manager.Navigator.GoToGroupsPage();
            while (!manager.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + 1 + "]")))
                manager.Groups.Create(new GroupData("NewGroupName"));
        }
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldGroups = manager.Groups.GetGroupList();

            manager.Groups.Remove(1);

            List<GroupData> newGroups = manager.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
