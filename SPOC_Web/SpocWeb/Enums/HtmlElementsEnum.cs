using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpocWeb.Enums
{
    public enum HtmlElementsEnum
    {
        button,
        link,
        table,
        textbox,
        textarea,
        checkbox,
        radiobutton,
        dropdown,
        image,
        menu,
        notElement
    }

    public class InputTypes
    {
        public const string text = "text";
        public const string checkbox = "checkbox";
        public const string radio = "radio";
        public const string password = "password";
        public const string email = "email";
        public const string number = "number";
        public const string date = "date";
        public const string search = "search";
        public const string file = "file";
        public const string button = "button";
        public const string submit = "submit";
        public const string reset = "reset";
    }
}