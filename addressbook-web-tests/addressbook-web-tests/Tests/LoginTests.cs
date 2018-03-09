using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_web_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            manager.Auth.Logout();

            AccountData account = new AccountData("admin", "secret");
            manager.Auth.Login(account);
            Assert.IsTrue(manager.Auth.IsLoggedIn());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            manager.Auth.Logout();

            AccountData account = new AccountData("admin", "123456");
            manager.Auth.Login(account);
            Assert.IsFalse(manager.Auth.IsLoggedIn());
        }
    }
}
