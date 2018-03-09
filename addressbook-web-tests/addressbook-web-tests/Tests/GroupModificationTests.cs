using System;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModoficationTest()
        {
            GroupData newData = new GroupData("modifiedname");
            newData.Header = null;
            newData.Footer = "modFooter";
            manager.Groups.Modify(2, newData);
        }
    }
}