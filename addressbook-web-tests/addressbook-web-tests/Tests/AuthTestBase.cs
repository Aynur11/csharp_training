using NUnit.Framework;

namespace addressbook_web_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetupLogin()
        {
            manager.Auth.Login(new AccountData("admin", "secret"));
        }
    }
}
