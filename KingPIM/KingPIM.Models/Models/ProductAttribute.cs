using KingPIM.Models.Models;
using System.Collections.Generic;

namespace KingPIM.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public int? AttributeGroupId { get; set; }
        public virtual List<PreDifinedOptions> PreDeifinedOptions { get; set; }
    }
}
