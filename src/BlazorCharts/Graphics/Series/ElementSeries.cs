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

        #region 数据处理

        /// <summary>
        /// 系列序号，决定了系列显示顺序
        /// </summary>
        public int SeriesNumber { get; set; }

        /// <summary>
        /// 系列宽度，决定了系列占用多少空间，影响后续系列位置
        /// </summary>
        public int SeriesWidth { get; set; }

        /// <summary>
        /// 最大值：用于计算坐标轴
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// 最小值：用于计算坐标轴
        /// </summary>
        public double MinValue { get; set; }

        /// <summary>
        /// 数据分析
        /// </summary>
        public virtual void DataAnalysis()
        {

        }


        #endregion

    }

    public enum SeriesType
    {
        Column,
        Line,
        Area,
    }

}
