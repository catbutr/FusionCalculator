using FusionCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.ViewModels
{
    public class DemonListVM
    {
        public List<DemonVM> DemonList { get; set; } = [];

        public DemonListVM()
        {
            for(int i = 1; i <= 10; i++)
            {
                DemonList.Add(new DemonVM(i));
            }
        }
    }
}
