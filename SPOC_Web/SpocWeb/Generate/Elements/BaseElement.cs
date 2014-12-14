using System;
using System.Text;

namespace SpocWeb.Generate.Elements
{
    public abstract class BaseElement
    {
        public String GenerateElementInitializationCss(string name)
        {
            var element = new StringBuilder();
            element.AppendLine()
                .Append(Utils.AddTextWithSpaces(string.Format("[FindsBy(How = How.CssSelector, Using = '[data-sel-id='{0}'])]", name)))
                .AppendLine()
                .Append(Utils.AddTextWithSpaces("protected IWebElement " + name + " { get; set; };"))
                .AppendLine();

            return element.ToString();
        }

        public String GenerateElementInitializationId(string name)
        {
            var element = new StringBuilder();
            element.AppendLine()
                .Append(Utils.AddTextWithSpaces(string.Format("[FindsBy(How = How.Id, Using = '{0}')]", name)))
                .AppendLine()
                .Append(Utils.AddTextWithSpaces("protected IWebElement " + name + " { get; set; };"))
                .AppendLine();

            return element.ToString();
        }

        public String GenerateGetMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(Utils.AddTextWithSpaces(string.Format("public IWebElement Get{0}()", Utils.UpperCaseFirstLetter(name))))
                .AppendLine().Append(Utils.AddTextWithSpaces("{")).AppendLine();
            Utils.IncreaseSpaceCounter();
            method.Append(Utils.AddTextWithSpaces(string.Format("return {0};", name))).AppendLine();
            Utils.DecreaseSpaceCounter();
            method.Append(Utils.AddTextWithSpaces("}"))
                .AppendLine();

            return method.ToString();
        }

        public abstract String GenerateSetMethod(string name);

        public abstract String GenerateClickMethod(string name);
    }
}
