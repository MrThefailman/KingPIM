﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    [Serializable]
    public class CategoryExportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<SubcategoryExportViewModel> Subcategories { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
    }
}
