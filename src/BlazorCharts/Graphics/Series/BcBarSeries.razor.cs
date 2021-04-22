using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcBarSeries<TData> : ElementSeries<TData>
    {
        public BcBarSeries() : base(SeriesType.Bar)
        {

        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }
        public override void InitLayout()
        {

            base.InitLayout();
        }
    }
}
