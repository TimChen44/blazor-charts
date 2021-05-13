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
            //计算拥有的分类以及分类的位置
            CategoryDatas = new List<CategoryData>();
            for (int i = 0; i < categorys.Count; i++)
            {
                CategoryDatas.Add(new CategoryData()
                {
                    Name = categorys[i],
                    LocationRatio = (i + 0.5) / categorys.Count,
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
        /// 分类在轴上占用的宽度比，真实值需要乘以轴的长度
        /// </summary>
        public double WidthRatio => 1 / (CategoryDatas.Count == 0 ? 1 : CategoryDatas.Count);


        ///// <summary>
        ///// 系列的宽度
        ///// </summary>
        //public int SeriesWidth { get => (int)(Rect.W / (Categories.Count == 0 ? 1 : Categories.Count)); }
    }



}
