using FusionCalculator.Database.Tables;
using FusionCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.Models
{
    public class FusionPair
    {
        public Demon demon1 { get; set; }
        public Demon demon2 { get; set; }

        public FusionPair(Demon demon1, Demon demon2)
        {
            this.demon1 = demon1;
            this.demon2 = demon2;
        }

        public FusionPair()
        {

        }
    }
}
