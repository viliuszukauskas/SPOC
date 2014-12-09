using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebApplication1.OurContent.Models;

namespace WebApplication1.OurContent.Generate
{
    public class Generator
    {
        public StringBuilder PageClass = new StringBuilder();
        public int SpaceCounter = 4;

        public void GenerateFileHeader()
        {
            PageClass.Append("namespace XXX")
                .AppendLine()
                .Append("{")
                .AppendLine()
                .Append(AddTextWithSpaces("public class ChangeAccordingly")).
                AppendLine().Append(AddTextWithSpaces("{"));
            IncreaseSpaceCounter();
        }

        public void GeneratePageObjectFile(List<PageObjectsModel> elements)
        {
            GenerateFileHeader();

            GenerateFileBody(elements);

            GenerateFileFooter();
        }

        public void GenerateFileBody(List<PageObjectsModel> elements)
        {
            
        }

    public String GenerateElementInitialization(string name, string how)
        {
            var element = new StringBuilder();
            element.AppendLine()
                .Append(AddTextWithSpaces(string.Format("[FindsBy(How = How.{0}, Using = '{1}')]", how, name)))
                .AppendLine()
                .Append(AddTextWithSpaces("protected IWebElement " + name + " { get; set; };"));

            return element.ToString();
        }

        public String GenerateGetMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(AddTextWithSpaces(string.Format("public IWebElement Get{0}()", name)))
                .AppendLine().Append(AddTextWithSpaces("{"));
            IncreaseSpaceCounter();
            method.Append(AddTextWithSpaces(string.Format("return {0};", name))).AppendLine();
            DecreaseSpaceCounter();
            method.Append("}");

            return method.ToString();
        }

        public String GenerateSetMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(AddTextWithSpaces(string.Format("public XXX SetValue{0}(string what)", name)))
                .AppendLine().Append(AddTextWithSpaces("{"));
            IncreaseSpaceCounter();
            method.Append(AddTextWithSpaces(string.Format("{0}.clear();", name))).AppendLine();
            method.Append(AddTextWithSpaces(string.Format("{0}.sendKeys(what);", name))).AppendLine();
            method.Append(AddTextWithSpaces("return this;")).AppendLine();
            DecreaseSpaceCounter();
            method.Append("}");

            return method.ToString();
        }

        public void GenerateFileFooter()
        {
            DecreaseSpaceCounter();
            PageClass.Append(AddTextWithSpaces("}")).AppendLine().Append(AddTextWithSpaces("}"));
        }

        public void WriteToFile()
        {
            using (var outfile = new StreamWriter(@"\AllTxtFiles.txt"))
            {
                outfile.Write(PageClass.ToString());
            }
        }

        public String AddTextWithSpaces(string text)
        {
            var a = "";
            return a.PadRight(SpaceCounter) + text;
        }

        public void IncreaseSpaceCounter()
        {
            SpaceCounter += 4;
        }

        public void DecreaseSpaceCounter()
        {
            SpaceCounter -= 4;
        }
    }
}
