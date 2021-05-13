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
            var lastSeriesNumber = Series.LastOrDefault()?.SeriesNumber ?? 0;
            element.SeriesNumber = lastSeriesNumber + 1;
            Series.Add(element);
        }

        internal void DataAnalysis(List<TData> datas, List<string> categorys)
        {
            foreach (var item in Series)
            {
                item.DataAnalysis(datas, categorys);
            }
            Categories = categorys.Select(x => new CategoryAxes(x)).ToList();

            GroupNames = Series.SelectMany(x => x.SeriesData.Groups).ToList();
        }

        public override void Drawing()
        {
            //计算绘图区
            Rect.X = Chart.BcAxisGroup.AxesYLeft.Rect.R;
            Rect.Y = Chart.BcAxisGroup.AxesYLeft.Rect.T;

            Rect.W = Chart.BcAxisGroup.AxesX.Rect.R - Rect.X;
            Rect.H = Chart.BcAxisGroup.AxesX.Rect.T - Rect.Y;

            for (int i = 0; i < Categories.Count; i++)
            {
                var cat = Categories[i];
                cat.LocationRatio = (i + 0.5) / Categories.Count;
            }

            foreach (var item in Series)
            {
                item.Drawing();
            }

            base.Drawing();
        }

        /// <summary>
        /// 所有分类名称
        /// </summary>
        public List<CategoryAxes> Categories { get; set; } = new List<CategoryAxes>();

        /// <summary>
        /// 所有组名称
        /// </summary>
        public List<string> GroupNames { get; set; } = new List<string>();


        /// <summary>
        /// 分类在轴上占用的宽度比，真实值需要乘以轴的长度
        /// </summary>
        public double WidthRatio => 1 / (Categories.Count == 0 ? 1 : Categories.Count);


        ///// <summary>
        ///// 系列的宽度
        ///// </summary>
        //public int SeriesWidth { get => (int)(Rect.W / (Categories.Count == 0 ? 1 : Categories.Count)); }
    }

    /// <summary>
    /// 分类的区域，
    /// </summary>
    public class CategoryAxes
    {
        public CategoryAxes(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        /// <summary>
        /// 分类在轴上的位置比，真实值需要乘以轴的长度
        /// </summary>
        public double LocationRatio { get; set; }

    }


}
