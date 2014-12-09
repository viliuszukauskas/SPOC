using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WebApplication1.OurContent.Enums;
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

            WriteToFile();
        }

        public void GenerateFileBody(List<PageObjectsModel> elements)
        {
            foreach (var element in elements)
            {
                //first lets add elements..
                switch (element.How)
                {
                    case SelectorType.CssSelector:
                        PageClass.Append(GenerateElementInitializationCss(element.Id));
                        break;
                    case SelectorType.Id:
                        PageClass.Append(GenerateElementInitializationId(element.Id));
                        break;
                }

                //.. and then methods
                if (element.Type.Equals("text"))
                {
                    PageClass.Append(GenerateGetMethod(element.Id));
                    PageClass.Append(GenerateSetMethod(element.Id));
                } else if (element.Type.Equals("checkbox"))
                {
                    PageClass.Append(GenerateGetMethod(element.Id));
                    PageClass.Append(GenerateClickMethod(element.Id));
                }
            }
        }

        public String GenerateElementInitializationCss(string name)
        {
            var element = new StringBuilder();
            element.AppendLine()
                .Append(AddTextWithSpaces(string.Format("[FindsBy(How = How.CssSelector, Using = '[data-sel-id='{0}'])]", name)))
                .AppendLine()
                .Append(AddTextWithSpaces("protected IWebElement " + name + " { get; set; };"))
                .AppendLine();

            return element.ToString();
        }

        public String GenerateElementInitializationId(string name)
        {
            var element = new StringBuilder();
            element.AppendLine()
                .Append(AddTextWithSpaces(string.Format("[FindsBy(How = How.Id, Using = '{0}')]", name)))
                .AppendLine()
                .Append(AddTextWithSpaces("protected IWebElement " + name + " { get; set; };"))
                .AppendLine();

            return element.ToString();
        }

        public String GenerateGetMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(AddTextWithSpaces(string.Format("public IWebElement Get{0}()", UpperCaseFirstLetter(name))))
                .AppendLine().Append(AddTextWithSpaces("{")).AppendLine();
            IncreaseSpaceCounter();
            method.Append(AddTextWithSpaces(string.Format("return {0};", name))).AppendLine();
            DecreaseSpaceCounter();
            method.Append(AddTextWithSpaces("}"))
                .AppendLine();

            return method.ToString();
        }

        public String GenerateSetMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(AddTextWithSpaces(string.Format("public XXX SetValue{0}(string what)", UpperCaseFirstLetter(name))))
                .AppendLine().Append(AddTextWithSpaces("{")).AppendLine();
            IncreaseSpaceCounter();
            method.Append(AddTextWithSpaces(string.Format("{0}.clear();", name))).AppendLine();
            method.Append(AddTextWithSpaces(string.Format("{0}.sendKeys(what);", name))).AppendLine();
            method.Append(AddTextWithSpaces("return this;")).AppendLine();
            DecreaseSpaceCounter();
            method.Append(AddTextWithSpaces("}"))
                .AppendLine();

            return method.ToString();
        }

        public String GenerateClickMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(AddTextWithSpaces(string.Format("public XXX Click{0}(bool clicked)", UpperCaseFirstLetter(name))))
                .AppendLine().Append(AddTextWithSpaces("{")).AppendLine();
            IncreaseSpaceCounter();
            method.Append(AddTextWithSpaces(string.Format("{0}.click();", name))).AppendLine();
            method.Append(AddTextWithSpaces("return this;")).AppendLine();
            DecreaseSpaceCounter();
            method.Append(AddTextWithSpaces("}"))
                .AppendLine();

            return method.ToString();
        }

        public void GenerateFileFooter()
        {
            DecreaseSpaceCounter();
            PageClass.AppendLine();
            PageClass.Append(AddTextWithSpaces("}")).AppendLine();
            DecreaseSpaceCounter();
            PageClass.Append(AddTextWithSpaces("}"));
        }

        public void WriteToFile()
        {
            string rootFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string folderPath = Path.Combine(rootFolderPath, "SPOC_Output_Folder");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var fileLocation = Path.Combine(folderPath, "PageObject.txt");
            
            using (var sw = new StreamWriter(fileLocation, false))
            {
                sw.Write(PageClass.ToString());
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

        public string UpperCaseFirstLetter(string s)
        {
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
