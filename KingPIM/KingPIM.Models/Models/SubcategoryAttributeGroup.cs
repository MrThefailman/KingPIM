using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPIM.Models.Models
{
    public class SubcategoryAttributeGroup
    {
        public virtual Subcategory Subcategory { get; set; }
        [Key, Column(Order = 0)]
        public int? SubcategoryId { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        [Key, Column(Order = 1)]
        public int? AttributeGroupId { get; set; }
    }
}
