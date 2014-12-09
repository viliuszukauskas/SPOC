using SPOC.Enums;

namespace SPOC.Models
{
    public class PageObjectsModel
    {
        public string Id { get; set; }
        public SelectorType How { get; set; }
        public string Type { get; set; }
        public string TagName { get; set; }
    }
}
