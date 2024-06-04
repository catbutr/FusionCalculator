using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Database.Tables
{
    [Table("Resistances")]
    class Resistances
    {
        [PrimaryKey]
        [Column("DemonID")]
        public int DemonID { get; set; }

        [Column("Phys")]
        public string Phys { get; set; }

        [Column("Gun")]
        public string Gun { get; set; }

        [Column("Fire")]
        public string Fire { get; set; }

        [Column("Ice")]
        public string Ice { get; set; }

        [Column("Elec")]
        public string Elec { get; set; }

        [Column("Force")]
        public string Force { get; set; }

        [Column("Nerve")]
        public string Nerve { get; set; }

        [Column("Expel")]
        public string Expel { get; set; }

        [Column("Death")]
        public string Death { get; set; }

        [Column("Curse")]
        public string Curse { get; set; }

        [Column("Bind")]
        public string Bind { get; set; }

        [Column("Rush")]
        public string Rush { get; set; }

        [Column("Punch")]
        public string Punch { get; set; }

        [Column("Flying")]
        public string Flying { get; set; }

    }
}
