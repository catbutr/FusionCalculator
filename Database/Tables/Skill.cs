using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Database.Tables
{
    [Table("Skills")]
    public class Skill
    {
        [PrimaryKey, AutoIncrement]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Element")]
        public string Element { get; set; }

        [Column("Power")]
        public int Power { get; set; }

        [Column("Resistances")]
        public string Target { get; set; }

        [Column("Effect")]
        public string Effect { get; set; }

        [Column("Cost")]
        public int Cost { get; set; }

        [Column("Skill1")]
        public int Skill1 { get; set; }
        [Column("Skill2")]
        public int Skill2 { get; set; }
        [Column("Skill3")]
        public int Skill3 { get; set; }
    }
}
