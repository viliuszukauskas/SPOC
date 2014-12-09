using System.Collections.Generic;
using WebApplication1.OurContent.Enums;

namespace WebApplication1.OurContent.Models
{
    public class PageObjectsModel
    {
        public string Id { get; set; }
        public SelectorType How { get; set; }
        public string Type { get; set; }
        public string TagName { get; set; }
        public List<AttributesModel> Atributes { get; set; }
    }
}
