using System.IO;
using NUnit.Framework;
using WebApplication1.OurContent.Parser;

namespace WebApplication1.OurContent.Tests
{
    [TestFixture]
    public class PageObjectsParserTest
    {
        public PageObjectsParser Parser = new PageObjectsParser();

        [Test]
        public void TestParser()
        {
            var pathToFile = Path.GetFullPath(@"Tests/TestData.xml");
            Parser.CollectElementInPage(pathToFile);
        }

    }
}

