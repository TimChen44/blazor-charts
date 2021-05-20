using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcSeriesGroup<TData> : ElementChart<TData>
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 图表中的系列
        /// </summary>
        public List<ElementSeries<TData>> Series { get; set; } = new List<ElementSeries<TData>>();
        public void AddSeries(ElementSeries<TData> element)
        {
            element.SerialNumber = (Series.LastOrDefault()?.SerialNumber ?? -1) + 1;//设置系列的顺序号
            this.NeedSecondaryAxis = this.NeedSecondaryAxis || element.IsSecondaryAxis;
            Series.Add(element);
        }

        internal void DataAnalysis(List<TData> datas, List<string> categorys)
        {
            //计算拥有的分类以及分类的位置
            CategoryDatas = new List<CategoryData>();
            for (int i = 0; i < categorys.Count; i++)
            {
                CategoryDatas.Add(new CategoryData()
                {
                    Name = categorys[i],
                    ZeroOffsetRatio = (i + 0.5) / categorys.Count,
                });
            }

            //计算每个系列的数据
            foreach (var item in Series)
            {
                item.DataAnalysis(datas, CategoryDatas);
            }

            GroupNames = Series.SelectMany(x => x.SeriesData.Groups).ToList();
        }

        public override void Drawing()
        {
            //计算绘图区
            Rect.X = Chart.BcAxisGroup.AxesYLeft.Rect.R;
            Rect.Y = Chart.BcAxisGroup.AxesYLeft.Rect.T;

            Rect.W = Chart.BcAxisGroup.AxesX.Rect.R - Rect.X;
            Rect.H = Chart.BcAxisGroup.AxesX.Rect.T - Rect.Y;



            foreach (var item in Series)
            {
                item.Drawing();
            }

            base.Drawing();
        }


        /// <summary>
        /// 分类的数据
        /// </summary>
        public List<CategoryData> CategoryDatas { get; set; } = new List<CategoryData>();

        /// <summary>
        /// 所有组名称
        /// </summary>
        public List<string> GroupNames { get; set; } = new List<string>();

        /// <summary>
        /// 分组数量
        /// </summary>
        public int GroupCount => GroupNames.Count;

        /// <summary>
        /// 占用图标空间的分组数量
        /// </summary>
        public int GroupKeepCount => Series.Sum(x => x.GroupKeepRatio);

        /// <summary>
        /// 分类在轴上占用的宽度比，真实值需要乘以轴的长度,包含分类之间的空白区域
        /// </summary>
        public double CategoryWidthRatio => (double)1 / (CategoryDatas.Count == 0 ? 1 : CategoryDatas.Count);

        /// <summary>
        /// 单个分类的宽度,包含分类之间的空白区域
        /// </summary>
        public double CategoryWidth => Chart.BcAxisGroup.AxesX.Rect.W * Chart.BcSeriesGroup.CategoryWidthRatio; //所有系列的所有分组的宽度

        /// <summary>
        /// 分类占用的空间，就是排除了分组之间的留空
        /// </summary>
        public double CategoryKeepWidth => CategoryWidth - GroupWidth; //所有系列的所有分组的宽度

        /// <summary>
        /// 单个分组的宽度，已经考虑分类之间空白，所以宽度有所减少
        /// </summary>
        public double GroupWidth => (double)1 / (Series.Sum(x => x.GroupKeepRatio) + 1) * CategoryWidth;

        /// <summary>
        /// 需要次坐标，如果某个系列需要次坐标，那么默认就要显示
        /// </summary>
        public bool NeedSecondaryAxis { get; set; } = false;

    }



}
