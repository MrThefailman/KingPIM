﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models
{
    public class AttributeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<ProductAttribute> Attributes { get; set; }
    }
}
