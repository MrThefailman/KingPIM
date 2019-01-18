using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models.Models
{
    public class PreDifinedOptions
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
        public int? ProductAttributeId { get; set; }
    }
}
