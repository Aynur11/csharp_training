using System;
using NUnit.Framework;

namespace addressbook_web_tests.Tests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModoficationTest()
        {
            GroupData newData = new GroupData("modifiedname");
            newData.Header = "modHeader";
            newData.Footer = "modFooter";
            manager.Groups.Modify(2, newData);
        }
    }
}