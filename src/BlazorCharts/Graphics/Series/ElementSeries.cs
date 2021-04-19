using Microsoft.AspNetCore.Components;
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
            Type = type;
        }

        /// <summary>
        /// 系列组对象
        /// </summary>
        [CascadingParameter] public BcSeriesGroup<TData> SeriesGroup { get; set; }

        /// <summary>
        /// 系列类型
        /// </summary>
        public SeriesType Type { get; set; }


        /// <summary>
        /// 图例（系列）字段
        /// </summary>
        [Parameter] public string Name { get; set; }

        /// <summary>
        /// 值字段
        /// </summary>
        [Parameter] public Func<List<TData>, double> ValueFunc { get; set; }

        /// <summary>
        /// 系列的数据，界面就给予这个数据呈现
        /// </summary>
        public SeriesData<TData> SeriesDatas { get; set; }


        public override void InitLayout()
        {

        }
    }

    public enum SeriesType
    {
        Bar,
    }
}
