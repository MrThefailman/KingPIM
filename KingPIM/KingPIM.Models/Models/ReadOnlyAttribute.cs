using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace KingPIM.Models
{
    // This doesnt save in the database
    public class ReadOnlyAttribute
    {
        [Column(Order = 10)]
        public DateTime AddedDate { get; set; }
        [Column(Order = 11)]
        public DateTime UpdatedDate { get; set; }
        [Column(Order = 12)]
        public bool Published { get; set; }
        [Column(Order = 13)]
        public double Version { get; set; }
        // TODO: add identity

    }
}
