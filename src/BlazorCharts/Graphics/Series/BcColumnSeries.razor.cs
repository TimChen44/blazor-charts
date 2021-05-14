using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcColumnSeries<TData> : ElementSeries<TData>
    {

        public BcColumnSeries() : base(SeriesType.Column)
        {

        }

        internal override int SeriesWidthRatio => SeriesData.Groups.Count ;

    }
}
