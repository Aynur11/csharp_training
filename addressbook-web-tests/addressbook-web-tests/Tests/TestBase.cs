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
            manager = ApplicationManager.GetInstance();

        }
    }
}
