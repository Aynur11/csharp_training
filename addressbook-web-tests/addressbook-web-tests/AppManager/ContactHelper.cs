using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        private List<ContactData> contactCache = null;
        public ContactHelper Create(ContactData data)
        {
            manager.Navigator.GoToHomePage();
            InitNewContact();
            FillContact(data);
            SubmitContactCreation();
            manager.Navigator.GoToHomePage();
            return this;
        }

        internal List<ContactData> GetContactsList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//tr[@name='entry'])"));
                foreach (IWebElement element in elements)
                {
                    var td = element.FindElements(By.TagName("td"));
                    contactCache.Add(new ContactData(td[2].Text, td[1].Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("(//tr[@name='entry'])")).Count;

        }

        public ContactHelper Modify(int index, ContactData contactData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            FillContact(contactData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        public ContactHelper InitNewContact()
        {
           driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }
        
        private ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@name='submit']")).Click();
            contactCache = null;
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }

        public ContactHelper FillContact(ContactData entryData)
        {
            Type(By.Name("firstname"), entryData.Firstname);
            Type(By.Name("lastname"), entryData.Lastname);
            return this;
        }
        
        public ContactHelper Remove(int index)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(index);
            RemoveContact();
            manager.Navigator.GoToHomePage();
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
            contactCache = null;
            return this;
        }
    }
}
