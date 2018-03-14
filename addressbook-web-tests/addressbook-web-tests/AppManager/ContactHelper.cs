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
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//tr[@name='entry'])"));

            // string[] s;
            foreach (IWebElement element in elements)
            {
                ICollection<IWebElement> tdcells =  element.FindElements(By.XPath("(/td)"));
                string[] s = new string[10];
                int i = 0;
                foreach (IWebElement cell in tdcells)
                {
                    if (i < 1)
                    s[i] = cell.Text;
                    Console.WriteLine(s[i]);
                    i++;
                }
                contacts.Add(new ContactData(s[1], s[0]));
                //s = element.Text.Split(' ');
                //Console.WriteLine(s[1]);
                //Console.WriteLine(s[0]);
                //contacts.Add(new ContactData(s[1], s[0]));
            }
            return contacts;
        }

        public ContactHelper Modify(int index, ContactData contactData)
        {
            manager.Navigator.GoToHomePage();
            CreateContactIfNotExists(index);
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
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("//input[@name='submit']")).Click();
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
            CreateContactIfNotExists(index);
            SelectContact(index);
            RemoveContact();
            return this;
        }

        public ContactHelper CreateContactIfNotExists(int index)
        {
            while (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
                Create(new ContactData("NewFirstname", "NewLastname"));
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
