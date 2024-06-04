using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionCalculator.ViewModels
{
    public class DemonListVM
    {
        public List<DemonVM> DemonList { get; set; } = new List<DemonVM>();

        public DemonListVM()
        {
            for(int i = 1; i <= 10; i++)
            {
                DemonList.Add(new DemonVM(i));
            }
        }
    }
}
