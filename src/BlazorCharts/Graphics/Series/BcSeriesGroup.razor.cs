using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcSeriesGroup<TData> : Element<TData>
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 图表中的系列
        /// </summary>
        public List<ElementSeries<TData>> Series { get; set; } = new List<ElementSeries<TData>>();
        public void AddSeries(ElementSeries<TData> element)
        {
            Series.Add(element);
        }


        protected override void OnInitialized()
        {
            Console.WriteLine("BcSeriesGroup");
            base.OnInitialized();
        }


        /// <summary>
        /// 每一个分类的图表占用的位置
        /// 通常多个柱状图会通过平分此区域来显示
        /// </summary>
        public Dictionary<string, Rect> CategoryRects = new Dictionary<string, Rect>();


        public override void InitLayout()
        {
            //计算绘图区
            Rect.X = Chart.BcAxisGroup.AxesYLeft.Rect.R;
            Rect.Y = Chart.BcAxisGroup.AxesYLeft.Rect.T;

            Rect.W = Chart.BcAxisGroup.AxesX.Rect.R - Rect.X;
            Rect.H = Chart.BcAxisGroup.AxesX.Rect.T - Rect.Y;

            foreach (var category in Chart.BcAxisGroup.Categorys)
            {
                var rect = new Rect(0, 0, Chart.BcAxisGroup.CategoryDistance / 2, Rect.H);//此处假设永远占用一般，但是为了显示效果，这里可以做成一个递增比例
                rect.C = Chart.BcAxisGroup.CategoryPositions[category];

                CategoryRects.Add(category, rect);
            }

            foreach (var item in Series)
            {
                item.InitLayout();
            }

            base.InitLayout();
        }

    }


}
