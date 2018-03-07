using NUnit.Framework;

namespace addressbook_web_tests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        [SetUp]
        public void InitApllicationManager()
        {
            ApplicationManager manager = ApplicationManager.GetInstance();
            manager.Navigator.GoToHomePage();
            manager.Auth.Login();
        }
    }
}
