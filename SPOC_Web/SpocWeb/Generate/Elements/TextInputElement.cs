using System;
using System.Text;

namespace SpocWeb.Generate.Elements
{
    public class TextInputElement : BaseElement
    {
        public override String GenerateSetMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(Utils.AddTextWithSpaces(string.Format("public XXX SetValue{0}(string what)", Utils.UpperCaseFirstLetter(name))))
                .AppendLine().Append(Utils.AddTextWithSpaces("{")).AppendLine();
            Utils.IncreaseSpaceCounter();
            method.Append(Utils.AddTextWithSpaces(string.Format("{0}.clear();", name))).AppendLine();
            method.Append(Utils.AddTextWithSpaces(string.Format("{0}.sendKeys(what);", name))).AppendLine();
            method.Append(Utils.AddTextWithSpaces("return this;")).AppendLine();
            Utils.DecreaseSpaceCounter();
            method.Append(Utils.AddTextWithSpaces("}"))
                .AppendLine();

            return method.ToString();
        }

        public override string GenerateClickMethod(string name)
        {
            throw new NotImplementedException();
        }
    }
}