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

        //这两个值需要在这里统一给出
        ///// <summary>
        ///// 每一个分组在X轴上相对0点的偏移比例
        ///// 此处存储比例目的是为了方便图表缩放
        ///// </summary>
        //public double AxesZeroRatio { get; set; }

        ///// <summary>
        ///// 分类在轴上拥有的宽度
        ///// </summary>
        //public double AxesWidthRatio { get; set; }


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

    }


}
