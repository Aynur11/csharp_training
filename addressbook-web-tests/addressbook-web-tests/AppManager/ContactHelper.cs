using System;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public void FillContact(ContactData entryData)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(entryData.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(entryData.Lastname);
            driver.FindElement(By.Name("submit")).Click();
        }

        public void InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
