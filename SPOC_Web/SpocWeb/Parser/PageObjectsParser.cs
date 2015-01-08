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
                    How = SelectorType.CssSelector,
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

                model.Type = ReturnHtmlElement(model.TagName, model.Atributes);

                if (node.Attributes.Contains(selectorAttribute))
                {
                    model.Id = node.Attributes[selectorAttribute].Value;
                }
                else if (node.Attributes.Contains("id"))
                {
                    model.Id = node.Attributes["id"].Value;
                }
                modelList.Add(model);
            }
            return modelList;
        }

        //TODO add more 
        private string ReturnHtmlElement(string tag, List<AttributesModel> atribute)
        {
            if (tag.Equals("input"))
            {
               return GenerateElementOfInput(atribute.Find(x => x.Name.Equals("type")).Value).ToString();
            }
            if (tag.Equals("button"))
            {
                return HtmlElementsEnum.button.ToString();
            }
            if (tag.Equals("a"))
            {
                return HtmlElementsEnum.link.ToString();
            }
            return HtmlElementsEnum.notElement.ToString();
        }

        private HtmlElementsEnum GenerateElementOfInput(string type)
        {
            if (type.Equals(InputTypes.checkbox))
            {
                return HtmlElementsEnum.checkbox;
            }
            if (type.Equals(InputTypes.radio))
            {
                return HtmlElementsEnum.radiobutton;
            }
            if (type.Equals(InputTypes.text))
            {
                return HtmlElementsEnum.textbox;
            }
            if (type.Equals(InputTypes.password))
            {
                return HtmlElementsEnum.textbox;
            }
            if (type.Equals(InputTypes.email))
            {
                return HtmlElementsEnum.textbox;
            }
            if (type.Equals(InputTypes.number))
            {
                return HtmlElementsEnum.textbox;
            }
            if (type.Equals(InputTypes.date))
            {
                return HtmlElementsEnum.textbox;
            }
            if (type.Equals(InputTypes.search))
            {
                return HtmlElementsEnum.textbox;
            }
            if (type.Equals(InputTypes.file))
            {
                return HtmlElementsEnum.textbox;
            }
            if (type.Equals(InputTypes.button))
            {
                return HtmlElementsEnum.button;
            }
            if (type.Equals(InputTypes.submit))
            {
                return HtmlElementsEnum.button;
            }
            if (type.Equals(InputTypes.reset))
            {
                return HtmlElementsEnum.button;
            }
            else
                return HtmlElementsEnum.notElement;
        }

    }
}
