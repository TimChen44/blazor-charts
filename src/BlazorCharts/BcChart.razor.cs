using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcChart<TData>
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        #region 数据

        /// <summary>
        /// 数据
        /// </summary>
        [Parameter] public List<TData> Data { get; set; }

        /// <summary>
        /// 轴（类别）字段
        /// </summary>
        [Parameter] public Func<TData, string> CategoryField { get; set; }
        //TODO:暂时只支持本文，应该支持文本，数字，日期，且日期支持自定义排序规则
        //TODO:目前仅支持一个字段


        /// <summary>
        /// 图例（系列）字段
        /// </summary>
        [Parameter] public Func<TData, string> SeriesField { get; set; }

        /// <summary>
        /// 数据处理器
        /// </summary>
        public DataShredder<TData> DataShredder { get; set; }

        #endregion

        #region 图表属性

        /// <summary>
        /// 宽度
        /// </summary>
        [Parameter] public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Parameter] public int Height { get; set; }

        #endregion

        #region 图表元素

        /// <summary>
        /// 标题
        /// </summary>
        public BcTitle<TData> BcTitle { get; set; }

        /// <summary>
        /// 图例
        /// </summary>
        public BcLegend<TData> BcLegend { get; set; }

        /// <summary>
        /// 轴
        /// </summary>
        public BcAxisGroup<TData> BcAxisGroup { get; set; }

        /// <summary>
        /// 图表
        /// </summary>
        public BcSeriesGroup<TData> BcSeriesGroup { get; set; }

        public void AddElement(Element<TData> element)
        {
            switch (element)
            {
                case BcTitle<TData> bcTitle:
                    BcTitle = bcTitle;
                    break;
                case BcLegend<TData> bcLegend:
                    BcLegend = bcLegend;
                    break;
                case BcSeriesGroup<TData> bcSeriesGroup:
                    BcSeriesGroup = bcSeriesGroup;
                    break;
                case ElementSeries<TData> bcElementSeries:
                    BcSeriesGroup.AddSeries(bcElementSeries);
                    break;
            }
        }

        #endregion

        public BcChart()
        {
            DataShredder = new DataShredder<TData>(this);
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Drawing();

            }
        }




        public void Drawing()
        {
            if (Data == null) return;
            DataShredder.Smash();


            BcTitle?.InitLayout();
            BcAxisGroup?.InitLayout();



            StateHasChanged();
        }
    }
}

