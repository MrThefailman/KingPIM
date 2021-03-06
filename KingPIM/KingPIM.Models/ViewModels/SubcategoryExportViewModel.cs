﻿using KingPIM.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    [Serializable]
    public class SubcategoryExportViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public virtual List<ProductExportViewModel> Products { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
    }
}
