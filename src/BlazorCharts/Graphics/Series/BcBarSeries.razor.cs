using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcBarSeries<TData> : ElementSeries<TData>
    {
        /// <summary>
        /// 顺序号，多个柱状图需要合理排序
        /// </summary>
        public int SequenceNumber { get; set; } = 0;


        public BcBarSeries() : base(SeriesType.Bar)
        {

        }

        public override void InitLayout()
        {
            //给柱状图进行编号
            this.SequenceNumber = Chart.BcSeriesGroup.Series.Where(x => x is BcBarSeries<TData>).Max(x => ((BcBarSeries<TData>)x).SequenceNumber) + 1;

            base.InitLayout();
        }
    }
}
