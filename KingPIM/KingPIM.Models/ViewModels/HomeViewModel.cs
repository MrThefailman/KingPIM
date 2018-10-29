using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    public class HomeViewModel
    {
        // Identity
        [DataType(DataType.EmailAddress)]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        // To read all the categories
        public IEnumerable<Category> Categories { get; set; }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

    }
}
