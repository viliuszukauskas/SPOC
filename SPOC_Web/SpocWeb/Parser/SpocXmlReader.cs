using System;
using System.Collections.Generic;
using System.Linq;
using SpocWeb.Models;

namespace SpocWeb.Parser
{
    public class SpocXmlReader
    {
        public List<XmlReaderModel> GetReaderInfo(string console)
        {
            var modelList = new List<XmlReaderModel>();
            var readText = ReadFromText(console);

            foreach (var txt in readText)
            {
                if (txt.Contains("id="))
                {
                    var splitedText = txt.Split(Convert.ToChar(" "));

                    var data = new XmlReaderModel
                    {
                        Atributes = new List<AttributesModel>(),
                        Name = splitedText[0],
                    };

                    for (int i = 1; i < splitedText.Length; i++)
                    {
                        var atrTemp = splitedText[i].Split(Convert.ToChar("="));
                        if (atrTemp.Length == 2)
                        {
                            var atr = new AttributesModel
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

        private IEnumerable<string> ReadFromText(string console)
        {
            var temp = console.Split(Convert.ToChar("<")).ToList();
            return (from s in temp where !s.StartsWith("/") && s.StartsWith("") select s.Split(Convert.ToChar(">"))[0]).ToList();
        }

        private string ReplaceCharacters(string text)
        {
            return text.Replace("\\", "").Replace("\"", "");
        }
    }
}