using System.Collections.Generic;
using SpocWeb.Enums;

namespace SpocWeb.Models
{
    public class PageObjectsModel
    {
        public string Id { get; set; }
        public SelectorType How { get; set; }
        public string Type { get; set; }
        public string TagName { get; set; }
        public List<AttributesModel> Atributes { get; set; }
    }

    public class AttributesModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
