using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication1.OurContent.Models;

namespace WebApplication1.OurContent.Parser
{
    public class SpocXmlReader
    {
        private string _text;
        public SpocXmlReader(string pathToFile)
        {
            _text = File.ReadAllText(pathToFile);
        }

        public List<XmlReaderModel> GetReaderInfo()
        {
            var modelList = new List<XmlReaderModel>();

            var list = ReadFromText();
            list.Remove(string.Empty);

            foreach (var lst in list)
            {
                var data = new XmlReaderModel
                {
                    Atributes = new List<AttributesModel>(),
                };

                var temp = lst.Split(Convert.ToChar(" "));
                data.Name = temp[0];

                for (int i = 1; i < temp.Length; i++)
                {
                    var atrTemp = temp[i].Split(Convert.ToChar("="));
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

            for (int i = 0; i < modelList.Count; i++)
            {
                if (modelList[i].Atributes.Count == 0)
                {
                    modelList.Remove(modelList[i]);
                    i = i - 1;
                }
            }

            return modelList;
        }

        private List<string> ReadFromText()
        {
            var temp = _text.Split(Convert.ToChar("<"));

            return (from s in temp where !s.StartsWith("/") && s.StartsWith("") select s.Split(Convert.ToChar(">"))[0]).ToList();
        }

        private string ReplaceCharacters(string character)
        {
            return character.Replace("\\", "").Replace("\"", "");
        }
    }
}