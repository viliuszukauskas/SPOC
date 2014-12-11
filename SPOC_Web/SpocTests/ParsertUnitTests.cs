using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using SpocWeb.Enums;
using SpocWeb.Generate;
using SpocWeb.Models;
using SpocWeb.Parser;
using System.Collections.Generic;

namespace SpocTests
{
    [TestClass]
    public class ParsertUnitTests
    {
        public PageObjectsParser Parser = new PageObjectsParser();
        public Generator Generator = new Generator();

        [TestMethod]
        public void TestParser()
        {
            var pathToFile = Path.GetFullPath(@"Data/TestData.txt");
            Parser.CollectElementInPage(pathToFile,"data-sel-id");
        }

        [TestMethod]
        public void TestGenerator()
        {
            var list = new List<PageObjectsModel>();
            var a = new PageObjectsModel { How = SelectorType.CssSelector, Id = "abc", Type = "text", TagName = "input" };
            list.Add(a);
            a = new PageObjectsModel { How = SelectorType.Id, Id = "cba", Type = "checkbox", TagName = "input" };
            list.Add(a);

            Generator.GeneratePageObjectFile(list);
        }

    }
}
