using System.Collections.Generic;
using SpocWeb.Enums;
using SpocWeb.Models;
using HtmlAgilityPack;

namespace SpocWeb.Parser
{
    public class PageObjectsParser
    {
        public List<PageObjectsModel> CollectElementInPage(string console, string selectorAttribute)
        {
            var modelList = new List<PageObjectsModel>();

            var doc = new HtmlDocument();
            doc.LoadHtml(console);
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes(string.Format("//*[@id or @{0}]", selectorAttribute)))
            {
                var model = new PageObjectsModel
                {
                    TagName = node.Name,
                    Atributes = new List<AttributesModel>(),
                };

                foreach (var attribute in node.Attributes)
                {
                    var atr = new AttributesModel
                    {
                        Name = attribute.Name,
                        Value = attribute.Value,
                    };
                    model.Atributes.Add(atr);
                }

                if (node.Attributes.Contains("type"))
                {
                    model.Type = node.Attributes["type"].Value;
                }
                else
                {
                    model.Type = string.Empty;
                }

                if (node.Attributes.Contains(selectorAttribute))
                {
                    model.Id = node.Attributes[selectorAttribute].Value;
                    model.How = SelectorType.CssSelector;
                }
                else if (node.Attributes.Contains("id"))
                {
                    model.Id = node.Attributes["id"].Value;
                    model.How = SelectorType.Id;
                }
                modelList.Add(model);
            }
            return modelList;
        }
    }
}
