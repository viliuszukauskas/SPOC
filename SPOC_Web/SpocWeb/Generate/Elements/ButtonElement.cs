using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SpocWeb.Generate.Elements
{
    public class ButtonElement : BaseElement
    {
        public override string GenerateSetMethod(string name)
        {
            return "";
        }

        public override string GenerateClickMethod(string name)
        {
            var method = new StringBuilder();
            method.AppendLine()
                .Append(Utils.AddTextWithSpaces(string.Format("public XXX Click{0}()", Utils.UpperCaseFirstLetter(name))))
                .AppendLine().Append(Utils.AddTextWithSpaces("{")).AppendLine();
            Utils.IncreaseSpaceCounter();
            method.Append(Utils.AddTextWithSpaces(string.Format("{0}.click();", name))).AppendLine();
            method.Append(Utils.AddTextWithSpaces("return this;")).AppendLine();
            Utils.DecreaseSpaceCounter();
            method.Append(Utils.AddTextWithSpaces("}")).AppendLine();

            return method.ToString();
        }
    }
}