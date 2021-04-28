using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcScatterSeries<TData> : ElementSeries<TData>
    {
        public BcScatterSeries() : base(SeriesType.Line)
        {

        }
    }
}
