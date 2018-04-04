using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.GoToHomePage();
            ClearGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void RemoveContactFromGroup(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            manager.Navigator.GoToDetailsPage(contact.Id);
            if (manager.Navigator.GotoGroupMemberPage() == true)
            {
                SelectContact(contact.Id);
                RemoveContactFromGroup();
            }


        }

        private void RemoveContactFromGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='remove'])")).Click();
        }

        private void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }

        private void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        private void ClearGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");


            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email = email,
                Email2 = email2,
                Email3 = email3
            };
        }
        public string ConvertContactDataToString(ContactData contact)
        {
            //return contact.Firstname + " " + contact.Lastname
            //    + "\r\n" + contact.Address + "\r\n\r\n"
            //    + contact.AllPhonesWithPrefix +
            //    "\r\n\r\n" + contact.AllEmails;
            return GetContactString(contact);
        }

        public string GetContactString(ContactData contact)
        {
            string total = "";
            if (contact.Firstname != null && contact.Firstname != "")
            {
                total += contact.Firstname;
                if (contact.Lastname != null && contact.Lastname != "")
                    total += " ";
                else
                {
                    if ((contact.Address != null && contact.Address != "")
                        || (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
                        || (contact.AllEmails != null && contact.AllEmails != ""))
                        total += "\r\n";
                }
            }

            if (contact.Lastname != null && contact.Lastname != "")
            {
                total += contact.Lastname;
                if ((contact.Address != null && contact.Address != "")
                    || (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
                    || (contact.AllEmails != null && contact.AllEmails != ""))
                    total += "\r\n";
            }

            if (contact.Address != null && contact.Address != "")
            {
                total += contact.Address;
                if ((contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
                        || (contact.AllEmails != null && contact.AllEmails != ""))
                    total += "\r\n";
            }

            if (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != "")
            {
                if ((contact.Firstname != null && contact.Firstname != "")
                    || (contact.Lastname != null && contact.Lastname != "")
                    || (contact.Address != null && contact.Address != ""))
                    total += "\r\n";
                total += contact.AllPhonesWithPrefix;
                if (contact.AllEmails != null && contact.AllEmails != "")
                    total += "\r\n";
                else total = total.Trim();
            }

            if (contact.AllEmails != null && contact.AllEmails != "")
            {
                if ((contact.Firstname != null && contact.Firstname != "")
                    || (contact.Lastname != null && contact.Lastname != "")
                    || (contact.Address != null && contact.Address != "")
                    || (contact.AllPhonesWithPrefix != null && contact.AllPhonesWithPrefix != ""))
                    total += "\r\n";
                total += contact.AllEmails.Trim();
            }
            return total;
        }
        public string GetContactInformationFromDetails(int index)
        {
            manager.Navigator.GoToHomePage();
            manager.Navigator.GoToDetailsPage(index);
            return driver.FindElement(By.XPath("//div[@id='content']")).Text;
        }

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index - 1].FindElements(By.TagName("td"));
            string firstName = cells[2].Text;
            string lastName = cells[1].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;
            string allEmails = cells[4].Text;


            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
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
                    contactCache.Add(new ContactData(td[2].Text, td[1].Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
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

        public ContactHelper Modify(ContactData contact, ContactData contactData)
        {
            manager.Navigator.GoToHomePage();
            InitContactModification(contact.Id);
            FillContact(contactData);
            SubmitContactModification();
            manager.Navigator.GoToHomePage();
            return this;
        }

        private ContactHelper InitContactModification(string id)
        {
            driver.FindElement(By.XPath("(//a[@href='edit.php?id=" + id + "'])")).Click();
            return this;
        }

        private ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }
        
        public void CreateContactIfNotExists(int index)
        {
            manager.Navigator.GoToHomePage();
            while (!manager.Contacts.IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + index + "]")))
                manager.Contacts.Create(new ContactData("NewFirstname", "NewLastname"));
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
        public ContactHelper Remove(ContactData contact)
        {
            manager.Navigator.GoToHomePage();
            SelectContact(contact.Id);
            RemoveContact();
            manager.Navigator.GoToHomePage();
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper SelectContact(string id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]' and @value='" + id + "'])")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }
    }
}
