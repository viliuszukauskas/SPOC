using System.IO;
using NUnit.Framework;
using SPOC.Parser;

namespace SPOC.Tests
{
    [TestFixture]
    public class PageObjectsParserTest
    {
        public PageObjectsParser parser = new PageObjectsParser();

        [Test]
        public void TestParser()
        {
            string pathToFile = Path.GetFullPath(@"Tests/TestData.xml");
            parser.CollectElementInPage(pathToFile);
        }

    }
}

