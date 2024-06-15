using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Database.Tables
{
    [Table("Stats")]
    public class DemonStats
    {
        [PrimaryKey, AutoIncrement]
        [Column("DemonID")]
        public int DemonID { get; set; }

        [Column("Price")]
        public int Price { get; set; }

        [Column("HP")]
        public int HP { get; set; }

        [Column("MP")]
        public int MP { get; set; }

        [Column("Strength")]
        public int Strength { get; set; }

        [Column("Intelligence")]
        public int Intelligence { get; set; }

        [Column("Magic")]
        public int Magic { get; set; }

        [Column("Vitality")]
        public int Vitality { get; set; }

        [Column("Agility")]
        public int Agility { get; set; }

        [Column("Luck")]
        public int Luck { get; set; }

        [Column("CP")]
        public int CP { get; set; }

        [Column("NoA")]
        public int NoA { get; set; }

        [Column("P.Atk")]
        public int PAtk { get; set; }

        [Column("P.Hit")]
        public int PHit { get; set; }

        [Column("Defence")]
        public int Defence { get; set; }

        [Column("Evasion")]
        public int Evasion { get; set; }

        [Column("M.Atk")]
        public int MAtk { get; set; }

        [Column("M.Hit")]
        public int MHit { get; set; }


    }
}
