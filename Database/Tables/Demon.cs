using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Database.Tables
{
    [Table("Demons")]
    class Demon
    {
        [PrimaryKey, AutoIncrement, Unique]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Level")]
        public int Level { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Race")]
        public int Race { get; set; }

        [Column("StatsID")]
        public int StatsID { get; set; }

        [Column("ResistanceID")]
        public int ResistanceID { get; set; }

    }
}
