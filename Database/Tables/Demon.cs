using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Database.Tables
{
    [Table("Demons")]
    public class Demon
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

        [Column("Skill1")]
        public int Skill1 { get; set; }
        [Column("Skill2")]
        public int Skill2 { get; set; }
        [Column("Skill3")]
        public int Skill3 { get; set; }

    }
}
