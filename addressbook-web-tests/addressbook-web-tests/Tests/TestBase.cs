using System;
using System.Text;
using NUnit.Framework;

namespace addressbook_web_tests
{
    public class TestBase
    {
        protected ApplicationManager manager;

        [SetUp]
        public void SetupTest()
        {
            manager = new ApplicationManager();
            manager.Navigator.GoToHomePage();
            manager.Auth.Login();
        }

        [TearDown]
        public void TeardownTest()
        {
            manager.Stop();
        }
        
    }
}
