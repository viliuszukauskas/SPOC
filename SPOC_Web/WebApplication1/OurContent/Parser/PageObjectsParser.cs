using System.Collections.Generic;
using WebApplication1.OurContent.Enums;
using WebApplication1.OurContent.Models;

namespace WebApplication1.OurContent.Parser
{
    public class PageObjectsParser
    {
        private SpocXmlReader _spocXmlReader = new SpocXmlReader();

        public List<PageObjectsModel> CollectElementInPage(string pathToFile)
        {
            var node = _spocXmlReader.GetReaderInfo(pathToFile);

            var modelList = new List<PageObjectsModel>();

            for (int i = 0; i < node.Count; i++)
            {
                var model = new PageObjectsModel();
                bool isAtribute = false;

                var atribute = node[i].Atributes.Find(x => x.Key.Equals("data-sel-id"));
                if (atribute != null)
                {
                    model.TagName = node[i].Name;
                    model.Id = node[i].Atributes.Find(x => x.Key.Equals("data-sel-id")).Value;
                    model.How = SelectorType.CssSelector;

                    if (node[i].Atributes.Find(x => x.Key.Equals("type")) != null)
                    {
                        model.Type = node[i].Atributes.Find(x => x.Key.Equals("type")).Value;
                    }
                    isAtribute = true;
                }
                atribute = node[i].Atributes.Find(x => x.Key.Equals("id"));
                if (atribute != null)
                {
                    model.TagName = node[i].Name;
                    model.Id = node[i].Atributes.Find(x => x.Key.Equals("id")).Value;
                    model.How = SelectorType.Id;
                    model.Atributes = node[i].Atributes;

                    if (node[i].Atributes.Find(x => x.Key.Equals("type")) != null)
                    {
                        model.Type = node[i].Atributes.Find(x => x.Key.Equals("type")).Value;
                    }
                    isAtribute = true;
                }
                if (isAtribute)
                    modelList.Add(model);
            }
            return modelList;
        }
    }
}
