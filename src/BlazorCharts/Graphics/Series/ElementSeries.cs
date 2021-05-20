using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// 分组名称，这个系列的固定名称，与SeriesField属性互斥
        /// </summary>
        [Display(Name = "分组名称", Description = "使用一个固定分组名字，与SeriesField属性互斥")]
        [Parameter] public string GroupName { get; set; }

        /// <summary>
        /// 分组字段，通过某一给字段拆分成多个组，与GroupName属性互斥
        /// </summary>
        [Display(Name = "分组字段", Description = "通过某一给字段拆分成多个组，与GroupName属性互斥")]
        [Parameter] public Func<TData, string> GroupField { get; set; }

        /// <summary>
        /// 实际的值
        /// </summary>
        [Display(Name = "值方法", Description = "通过一个方法返回实际的值")]
        [Parameter] public Func<IEnumerable<TData>, double> ValueFunc { get; set; }

        /// <summary>
        /// 使用次坐标轴
        /// </summary>
        [Parameter] public bool IsSecondaryAxis { get; set; }

        public override void Drawing()
        {
            Rect = Chart.BcSeriesGroup.Rect.Copy();
        }

        /// <summary>
        /// 根据值或者这个值在X轴的高度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetHeightByValue(double value)
        {
            if (IsSecondaryAxis == false)
                return Chart.BcAxisGroup.AxesYLeft.GetHeightByValue(value);
            else
                return Chart.BcAxisGroup.AxesYRight.GetHeightByValue(value);
        }

        #region 数据处理

        /// <summary>
        /// 系列序号，决定了系列显示顺序
        /// </summary>
        internal int SerialNumber { get; set; }

        /// <summary>
        /// 分组的序号
        /// </summary>
        internal int GroupSerialNumber => Chart.BcSeriesGroup.Series.Where(x => x.SerialNumber < SerialNumber).Sum(x => (int?)x.GroupKeepRatio) ?? 0;

        /// <summary>
        /// 分组占用的空间的宽度，比如线图是0，柱状图一根柱子为1，两根为2
        /// </summary>
        abstract internal int GroupKeepRatio { get; }


        /// <summary>
        /// 系列数据
        /// </summary>
        public SeriesData SeriesData { get; set; }

        /// <summary>
        /// 数据分析
        /// </summary>
        public virtual void DataAnalysis(List<TData> datas, List<CategoryData> categoryDatas)
        {
            SeriesData = new SeriesData();

            SeriesData.CategoryDatas = categoryDatas;

            //获得分组及每个分组的数据
            Dictionary<string, List<TData>> groups;
            if (string.IsNullOrWhiteSpace(GroupName) == false)
                groups = new Dictionary<string, List<TData>>() { { GroupName, datas } };
            else
                groups = datas.GroupBy(x => GroupField(x)).ToDictionary(x => x.Key, x => x.ToList());

            SeriesData.Groups = groups.Select(x => x.Key).ToList();

            //获得具体的值
            foreach (var category in categoryDatas)
            {
                foreach (var group in groups)
                {
                    var seriesValue = new SeriesValue(category.Name, group.Key);

                    //TODO:此处可以将获取值做一个虚函数，具体获得值由各类型的系列自己实现
                    double value = ValueFunc(group.Value.Where(x => Chart.CategoryField(x) == category.Name));

                    seriesValue.Data = new SingleValueData(value);

                    SeriesData.SeriesValues.Add(seriesValue);
                }
            }

            //TODO:具体获得最大最小值应该由各类型的系列单独实现，应为有些最大值是连个组合并所得
            SeriesData.MaxValue = SeriesData.SeriesValues.Max(x => x.Data.Max);
            SeriesData.MinValue = SeriesData.SeriesValues.Min(x => x.Data.Min);

        }

        #endregion

    }

    public enum SeriesType
    {
        Column,
        Line,
        Area,
        Scatter,
    }

}
