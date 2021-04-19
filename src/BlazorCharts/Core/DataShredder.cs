using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 数据处理器，用于将数据处理成界面上需要的格式
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public class DataShredder<TData>
    {
        public BcChart<TData> Chart { get; set; }

        public DataShredder(BcChart<TData> chart)
        {
            Chart = chart;
        }

        /// <summary>
        /// 从数据中分析出的分组
        /// </summary>
        public List<string> CategoryValues { get; set; } = new List<string>();

        public double AxesYMax { get; set; }
        public double AxesYMin { get; set; }


        /// <summary>
        /// 处理数据
        /// </summary>
        public void Smash()
        {
            //TODO:先实现功能，性能啥的，不能存在的 :p 

            CategoryValues = Chart.Data.GroupBy(x => Chart.CategoryField(x)).Select(x => x.Key).ToList();

            AxesYMax = double.MinValue;
            AxesYMin = double.MaxValue;

            foreach (var series in Chart.BcSeriesGroup.Series)
            {
                var sData = new SeriesData<TData>(series.Name);
                if (Chart.SeriesField == null || string.IsNullOrWhiteSpace(series.Name))
                    sData.Values = Chart.Data.ToList();
                else
                    sData.Values = Chart.Data.Where(x => Chart.SeriesField(x) == series.Name).ToList();

                foreach (var xValue in CategoryValues)
                {
                    var value = series.ValueFunc(sData.Values.Where(x => Chart.CategoryField(x) == xValue).ToList());
                    sData.CategoryValue.Add(xValue, value);

                    if (value > AxesYMax) AxesYMax = value;
                    if (value < AxesYMin) AxesYMin = value;
                }

                series.SeriesDatas = sData;
            }
        }

    }

    /// <summary>
    /// 系列的数据
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public record SeriesData<TData>(string Name)
    {
        public List<TData> Values { get; set; }

        public Dictionary<string, double> CategoryValue { get; set; } = new Dictionary<string, double>();
    }
}
