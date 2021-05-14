using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcAreaSeries<TData> : ElementSeries<TData>
    {
        public BcAreaSeries() : base(SeriesType.Line)
        {

        }

        internal override int SeriesWidthRatio => 0;
    }
}
