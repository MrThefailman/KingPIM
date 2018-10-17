using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models
{
    // This doesnt save in the database
    public class ReadOnlyAttribute
    {
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
        // TODO: add identity

    }
}
