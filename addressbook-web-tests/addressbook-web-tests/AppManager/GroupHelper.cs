using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager)
            : base(manager)
        {
        }

        private List<GroupData> groupChache = null;
        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGrouptCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int index, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            //CreateGroupIfNotExists(index);
            SelectGroup(index);
            InitGroupModofication();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            //CreateGroupIfNotExists(index);
            SelectGroup(index);
            RemoveGroup(index);
            ReturnToGroupsPage();
            return this;
        }

        public void CreateGroupIfNotExists(int index)
        {
            manager.Navigator.GoToGroupsPage();
            while (!manager.Groups.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
                manager.Groups.Create(new GroupData("NewGroupName"));
        }
        public List<GroupData> GetGroupList()
        {
            if (groupChache == null)
            {
                groupChache = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//span[@class='group'])"));
                foreach (IWebElement element in elements)
                {
                    groupChache.Add(new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<GroupData>(groupChache);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.XPath("(//span[@class='group'])")).Count;
        }

        //public GroupHelper CreateGroupIfNotExists(int index)
        //{
        //    while (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
        //        Create(new GroupData("NewGroupName"));
        //    return this;
        //}
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupChache = null;
            return this;
        }

        public GroupHelper InitGroupModofication()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupChache = null;
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper InitGrouptCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper RemoveGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])")).Click();
            groupChache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
    }
}