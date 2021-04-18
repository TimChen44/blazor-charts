using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public class ElementSeries<TData> : Element<TData>
    {
        public ElementSeries(SeriesType type)
        {
            SeriesType = type;
        }

        /// <summary>
        /// 值字段
        /// </summary>
        public Func<TData, double> ValueField { get; set; }

        public SeriesType SeriesType { get; set; }

        public override void Init()
        {
     
        }
    }

    public enum SeriesType
    {
        Bar,
    }
}
