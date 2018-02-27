using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
namespace addressbook_web_tests
{
    public class LoginHelper : HelperBase
    {
        private AccountData account;
        public LoginHelper(ApplicationManager manager, AccountData account)
            : base(manager)
        {
            this.account = account;
        }
        public void Login()
        {
            manager.Driver.FindElement(By.Name("user")).Clear();
            manager.Driver.FindElement(By.Name("user")).SendKeys(account.Username);
            manager.Driver.FindElement(By.Name("pass")).Clear();
            manager.Driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            manager.Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void Logout()
        {
            manager.Driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
