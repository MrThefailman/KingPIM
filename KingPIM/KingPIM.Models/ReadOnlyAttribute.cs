using System;
using System.Collections.Generic;
using System.Text;

namespace KingPIM.Models
{
    // Denna sparas inte i databasen
    public class ReadOnlyAttribute
    {
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Published { get; set; }
        public double Version { get; set; }
        // TODO: add identity

    }
}
