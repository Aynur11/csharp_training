using System;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper InitNewContact()
        {
           driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContact(ContactData entryData)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(entryData.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(entryData.Lastname);
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            RemoveContact();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}
