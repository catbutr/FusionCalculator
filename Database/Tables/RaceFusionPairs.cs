using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Database.Tables
{
    [Table("RaceFusionPairs")]
    internal class RaceFusionPairs
    {
        [Column("RaceID")]
        public int RaceID { get; set; }
        [Column("First")]
        public int First { get; set; }
        [Column("Second")]
        public int Second { get; set; }
    }
}
