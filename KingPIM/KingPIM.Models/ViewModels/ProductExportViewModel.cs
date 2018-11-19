using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    public class ProductExportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubcategoryId { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public double Version { get; set; }
        public bool Published { get; set; }
    }
}
