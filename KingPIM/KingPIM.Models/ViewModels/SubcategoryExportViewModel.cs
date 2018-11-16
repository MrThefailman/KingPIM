using KingPIM.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    public class SubcategoryExportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool Published { get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
    }
}
