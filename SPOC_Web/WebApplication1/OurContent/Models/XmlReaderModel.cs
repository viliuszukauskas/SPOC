﻿using System.Collections.Generic;
using NUnit.Framework;

namespace WebApplication1.OurContent.Models
{
    public class XmlReaderModel
    {
        public string Name { get; set; }
        public List<AttributesModel> Atributes { get; set; }
    }

    public class AttributesModel
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}