using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public abstract class ElementSeries<TData> : Element<TData>
    {
        public ElementSeries(SeriesType type)
        {
            Type = type;
        }

        /// <summary>
        /// 系列类型
        /// </summary>
        public SeriesType Type { get; set; }


        /// <summary>
        /// 分组字段，可以将一个字段中的值分成不同的系列处理
        /// </summary>
        [Parameter] public string Group { get; set; }


        private string caption;
        /// <summary>
        /// 系列名字
        /// </summary>
        [Parameter]
        public string Caption
        {
            get => caption ?? Group;
            set => caption = value;
        }

        /// <summary>
        /// 使用次坐标轴
        /// </summary>
        [Parameter] public bool IsSecondaryAxis { get; set; }

        /// <summary>
        /// 值字段
        /// </summary>
        [Parameter] public Func<List<TData>, double> ValueFunc { get; set; }

        public override void Drawing()
        {
            Rect = Chart.BcSeriesGroup.Rect.Copy();
        }


    }

    public enum SeriesType
    {
        Bar,
        Line,
    }

}
