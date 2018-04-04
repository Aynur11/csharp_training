using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace addressbook_web_tests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL)
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url != baseURL + "/addressbook/")
                driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url != baseURL + "/addressbook/group.php" && !IsElementPresent(By.Name("new")))
                driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToDetailsPage(int index)
        {
            driver.FindElement(By.XPath("(//img[@title='Details'])[" + index + "]")).Click();
        }

        public void GoToDetailsPage(string id)
        {
            driver.FindElement(By.XPath("(//a[@href='view.php?id=" + id + "'])")).Click();
        }

        public bool GotoGroupMemberPage()
        {
            if (IsElementPresent(By.TagName("i")))
            {
                driver.FindElement(By.TagName("i")).FindElement(By.TagName("a")).Click();
                return true;
            }
            return false;
        }
    }
}
