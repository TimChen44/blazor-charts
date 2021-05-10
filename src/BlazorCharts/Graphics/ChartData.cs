using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 分类数据：数据以分类维度(X轴)的形式存储
    /// </summary>
    public class CategoryData<TData>
    {
        public CategoryData(string category)
        {
            Category = category;
        }

        #region 数据

        /// <summary>
        /// 分类名字
        /// </summary>
        public string Category { get; set; }

        //移动到每个系列对象中自己管理
        /// <summary>
        /// 每个系列的值
        /// </summary>
        public Dictionary<string, double> SeriesValues { get; set; } = new Dictionary<string, double>();

        /// <summary>
        /// 分组中原始的值
        /// </summary>
        public List<TData> DataValues { get; set; }

        #endregion

        #region 布局信息


        //移动到BcSeriesGroup管理
        /// <summary>
        /// 每一个分组在X轴上相对0点的偏移比例
        /// 此处存储比例目的是为了方便图表缩放
        /// </summary>
        public double AxesZeroRatio { get; set; }

        /// <summary>
        /// 分类在轴上拥有的宽度
        /// </summary>
        public double AxesWidthRatio { get; set; }

        #endregion
    }

    /// <summary>
    /// 分组数据：系列数据，以系列为单位记录记录一些数据
    /// </summary>
    public class SeriesData
    {
        public SeriesData(string seriesName)
        {
            SeriesName = seriesName;
        }

        public string SeriesName { get; set; }

        public double Max { get; set; }

        public double Min { get; set; }


    }
}
