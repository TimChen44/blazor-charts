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
        /// 分组字段，可以将一个字段中的值分成不同的系列处理
        /// </summary>
        [Parameter] public Func<TData, string> GroupField { get; set; }

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
                case BcAxisGroup<TData> bcAxisGroup:
                    BcAxisGroup = bcAxisGroup;
                    break;
                case ElementAxes<TData> axes:
                    BcAxisGroup.AddAxes(axes);
                    break;
            }
        }

        #endregion

        public BcChart()
        {

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
            this.DataAnalysis();


            BcTitle?.InitLayout();
            BcAxisGroup?.InitLayout();

            BcSeriesGroup?.InitLayout();


            StateHasChanged();
        }


        /// <summary>
        /// 处理数据
        /// </summary>
        public void DataAnalysis()
        {
            //TODO:先实现功能，性能啥的，不能存在的 :p 

            BcAxisGroup.CategoryValues = Data.GroupBy(x => CategoryField(x)).Select(x => x.Key).ToList();

            BcAxisGroup.AxesYMax = double.MinValue;//TODO:此处最大值和最小值应该要取整
            BcAxisGroup.AxesYMin = double.MaxValue;

            foreach (var series in BcSeriesGroup.Series)
            {
                var sData = new SeriesData<TData>(series.Group);
                if (GroupField == null || string.IsNullOrWhiteSpace(series.Group))
                    sData.Values = Data.ToList();
                else
                    sData.Values = Data.Where(x => GroupField(x) == series.Group).ToList();

                foreach (var xValue in BcAxisGroup.CategoryValues)
                {
                    var value = series.ValueFunc(sData.Values.Where(x => CategoryField(x) == xValue).ToList());
                    sData.CategoryValue.Add(xValue, value);

                    if (value > BcAxisGroup.AxesYMax) BcAxisGroup.AxesYMax = value;
                    if (value < BcAxisGroup.AxesYMin) BcAxisGroup.AxesYMin = value;
                }

                series.SeriesDatas = sData;
            }
        }
    }
}

