using SpocWeb.Enums;
using SpocWeb.Generate.Elements;
using SpocWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SpocWeb.Generate
{
    public class Generator
    {
        public StringBuilder PageClass = new StringBuilder();

        public TextInputElement TextInputElement = new TextInputElement();
        public CheckboxElement CheckboxElement = new CheckboxElement();
        
        public string GeneratePageObjectFile(List<PageObjectsModel> elements)
        {
            GenerateFileBody(elements);

            return WriteToFile();
        }

        public void GenerateFileBody(List<PageObjectsModel> elements)
        {
            foreach (var element in elements)
            {
                //first lets add elements..
                switch (element.How)
                {
                    case SelectorType.CssSelector:
                        PageClass.Append(TextInputElement.GenerateElementInitializationCss(element.Id));
                        break;
                    case SelectorType.Id:
                        PageClass.Append(TextInputElement.GenerateElementInitializationId(element.Id));
                        break;
                }

                //.. and then methods
                if (element.Type.Equals("text"))
                {
                    PageClass.Append(TextInputElement.GenerateGetMethod(element.Id));
                    PageClass.Append(TextInputElement.GenerateSetMethod(element.Id));
                } else if (element.Type.Equals("checkbox"))
                {
                    PageClass.Append(CheckboxElement.GenerateGetMethod(element.Id));
                    PageClass.Append(CheckboxElement.GenerateClickMethod(element.Id));
                }
            }
        }
        
        public string WriteToFile()
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

            return File.ReadAllText(fileLocation);
        }
    }
}
