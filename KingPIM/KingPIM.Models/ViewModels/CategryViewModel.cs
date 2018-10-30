using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    public class CategoryViewModel
    {
        // To read all the categories
        public IEnumerable<Category> Categories { get; set; }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Published { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int CategoryId { get; set; }

    }
}
