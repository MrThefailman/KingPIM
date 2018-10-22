using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPIM.Models
{
    public class ProductAttributeValue
    {

        public virtual ProductAttribute ProductAttribute { get; set; }
        [Key, Column(Order = 0)]
        public int ProductAttributeId { get; set; }
        public virtual Product Product { get; set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }
        public string Value { get; set; }

        
    }
}
