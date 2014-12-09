using System.IO;
using NUnit.Framework;
using WebApplication1.OurContent.Enums;
using WebApplication1.OurContent.Generate;
using WebApplication1.OurContent.Models;
using WebApplication1.OurContent.Parser;
using System.Collections.Generic;

namespace WebApplication1.OurContent.Tests
{
    [TestFixture]
    public class PageObjectsParserTest
    {
        public PageObjectsParser Parser = new PageObjectsParser();
        public Generator Generator = new Generator();

        [Test]
        public void TestParser()
        {
            var pathToFile = Path.GetFullPath(@"Tests/TestData.xml");
            Parser.CollectElementInPage(pathToFile);
        }

        [Test]
        public void TestGenerator()
        {
            var list = new List<PageObjectsModel>();
            var a = new PageObjectsModel {How = SelectorType.Css, Id = "abc", Type = "text", TagName = "input"};
            list.Add(a);
            a = new PageObjectsModel { How = SelectorType.Id, Id = "cba", Type = "text", TagName = "input" };
            list.Add(a);

            Generator.GeneratePageObjectFile(list);
        }
    }
}