using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace KingPIM.Models.ViewModels
{
    public class LoginViewModel
    {
        // Identity
        [DataType(DataType.EmailAddress)]
        [Required]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

    }
}
