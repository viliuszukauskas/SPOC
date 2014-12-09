using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using WebApplication1.OurContent.Models;

namespace WebApplication1.OurContent.Parser
{
    public class SpocXmlReader
    {
        public List<XmlReaderModel> GetReaderInfo(string pathToFile)
        {
            var modelList = new List<XmlReaderModel>();
            var readText = ReadFromText(pathToFile);

            foreach (var txt in readText)
            {
                if (txt.Contains(" id="))
                {
                    var splitedText = txt.Split(Convert.ToChar(" "));

                    var data = new XmlReaderModel
                    {
                        Atributes = new List<AttributesModel>(),
                    };

                    data.Name = splitedText[0];

                    for (int i = 1; i < splitedText.Length; i++)
                    {
                        var atrTemp = splitedText[i].Split(Convert.ToChar("="));
                        if (atrTemp.Length == 2)
                        {
                            var atr = new AttributesModel()
                            {
                                Key = ReplaceCharacters(atrTemp[0]),
                                Value = ReplaceCharacters(atrTemp[1]),
                            };
                            data.Atributes.Add(atr);
                        }
                    }
                    modelList.Add(data);
                }
            }
            return modelList;
        }

        private List<string> ReadFromText(string pathToFile)
        {
            var temp = File.ReadAllText(pathToFile).Split(Convert.ToChar("<")).ToList();
            return (from s in temp where !s.StartsWith("/") && s.StartsWith("") select s.Split(Convert.ToChar(">"))[0]).ToList();
        }

        private string ReplaceCharacters(string text)
        {
            return text.Replace("\\", "").Replace("\"", "");
        }
    }
}