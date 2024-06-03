using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Database.Tables
{
    [Table("Resistance")]
    class Resistances
    {
        [PrimaryKey]
        [Column("DemonID")]
        public int DemonID { get; set; }

        [Column("Phys")]
        public int Phys { get; set; }

        [Column("Gun")]
        public int Gun { get; set; }

        [Column("Fire")]
        public int Fire { get; set; }

        [Column("Ice")]
        public int Ice { get; set; }

        [Column("Elec")]
        public int Elec { get; set; }

        [Column("Force")]
        public int Force { get; set; }

        [Column("Nerve")]
        public int Nerve { get; set; }

        [Column("Expel")]
        public int Expel { get; set; }

        [Column("Death")]
        public int Death { get; set; }

        [Column("Curse")]
        public int Curse { get; set; }

        [Column("Bind")]
        public int Bind { get; set; }

        [Column("Rush")]
        public int Rush { get; set; }

        [Column("Punch")]
        public int Punch { get; set; }

        [Column("Flying")]
        public int Flying { get; set; }

    }
}
