using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public int AttributeGroupId { get; set; }
        public string Type { get; set; }
    }
}
