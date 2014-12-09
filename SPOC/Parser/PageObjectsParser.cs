using System.Collections.Generic;
using System.Xml;
using SPOC.Enums;
using SPOC.Models;

namespace SPOC.Parser
{
    public class PageObjectsParser
    {
        public List<PageObjectsModel> CollectElementInPage(string pathToFile)
        {
            var doc = new XmlDocument();
            doc.Load(pathToFile);

            var node = doc.GetElementsByTagName("*");

            var modelList = new List<PageObjectsModel>();

            for (int i = 0; i < node.Count; i++)
            {
                var model = new PageObjectsModel();
                bool isAtribute = false;

                var atribute = node[i].Attributes;
                if (atribute != null && atribute["data-sel-id"] != null)
                {
                    model.TagName = node[i].Name;
                    model.Id = atribute["data-sel-id"].Value;
                    model.How = SelectorType.Css;

                    if (atribute["type"] != null)
                    {
                        model.Type = atribute["type"].Value;
                    }
                    isAtribute = true;
                }
                else if (atribute != null && atribute["id"] != null)
                {
                    model.TagName = node[i].Name;
                    model.Id = atribute["id"].Value;
                    model.How = SelectorType.Id;

                    if (atribute["type"] != null)
                    {
                        model.Type = atribute["type"].Value;
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
