using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcBarSeries: Element
    {
        protected override void OnInitialized()
        {
            Console.WriteLine("BcBarSeries");
            base.OnInitialized();
        }
    }
}
