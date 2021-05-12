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
        /// 分组名称，这个系列的固定名称，与SeriesField属性互斥
        /// </summary>
        [Parameter] public string GroupName { get; set; }

        /// <summary>
        /// 分组字段，通过某一给字段拆分成多个组，与GroupName属性互斥
        /// </summary>
        [Parameter] public Func<TData, string> GroupField { get; set; }

        /// <summary>
        /// 实际的值
        /// </summary>
        [Parameter] public Func<IEnumerable<TData>, double> ValueFunc { get; set; }

        /// <summary>
        /// 使用次坐标轴
        /// </summary>
        [Parameter] public bool IsSecondaryAxis { get; set; }

        public override void Drawing()
        {
            Rect = Chart.BcSeriesGroup.Rect.Copy();
        }

        #region 数据处理

        /// <summary>
        /// 系列序号，决定了系列显示顺序
        /// </summary>
        internal int SeriesNumber { get; set; }

        /// <summary>
        /// 系列宽度占比，比如线图是0，柱状图一根柱子为1，两根为2
        /// </summary>
        abstract internal int SeriesWidthRatio { get; }

        /// <summary>
        /// 系列数据
        /// </summary>
        public SeriesData SeriesData { get; set; }

        /// <summary>
        /// 数据分析
        /// </summary>
        public virtual void DataAnalysis(List<TData> datas, List<string> categorys)
        {
            SeriesData = new SeriesData();

            SeriesData.Categories = categorys;

            //获得分组及每个分组的数据
            Dictionary<string, List<TData>> groups;
            if (string.IsNullOrWhiteSpace(GroupName) == false)
                groups = new Dictionary<string, List<TData>>() { { GroupName, datas } };
            else
                groups = datas.GroupBy(x => GroupField(x)).ToDictionary(x => x.Key, x => x.ToList());

            SeriesData.Groups = groups.Select(x => x.Key).ToList();

            //获得具体的值
            foreach (var category in categorys)
            {
                var categoryData = new CategoryData(category);
                SeriesData.CategoryDatas.Add(category, categoryData);

                foreach (var group in groups)
                {
                    var groupData = new GroupData(group.Key);
                    categoryData.GroupDatas.Add(group.Key, groupData);

                    //TODO:此处可以将获取值做一个虚函数，具体获得值由各类型的系列自己实现
                    double value = ValueFunc(group.Value.Where(x => Chart.CategoryField(x) == category));

                    groupData.Data = new SingleValueData(value);
                }
            }

            //TODO:具体获得最大最小值应该由各类型的系列单独实现，应为有些最大值是连个组合并所得
            SeriesData.MaxValue = SeriesData.CategoryDatas.Max(x => x.Value.GroupDatas.Max(y => y.Value.Data.Max));
            SeriesData.MinValue = SeriesData.CategoryDatas.Min(x => x.Value.GroupDatas.Min(y => y.Value.Data.Max));

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
