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
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            manager.Driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        public void Logout()
        {
            manager.Driver.FindElement(By.LinkText("Logout")).Click();
        }

    }
}
