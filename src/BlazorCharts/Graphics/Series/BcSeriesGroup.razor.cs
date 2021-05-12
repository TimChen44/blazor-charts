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
        /// 获得所有组名
        /// </summary>
        /// <returns></returns>
        public  List<string> GetGroupNames()
        {
            return Series.SelectMany(x => x.SeriesData.Groups).ToList();
        }

    }


}
