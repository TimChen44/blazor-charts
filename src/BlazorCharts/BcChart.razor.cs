using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcChart<TData>
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

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
                    if (BcLegend == null)
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

        #region 数据

        /// <summary>
        /// 数据
        /// </summary>
        [Parameter] public List<TData> Data { get; set; }

        /// <summary>
        /// 轴（类别）字段
        /// </summary>
        [Parameter] public Func<TData, string> CategoryField { get; set; }

        /// <summary>
        /// 数据筛选：可以通过它筛选筛选数据
        /// </summary>
        [Parameter] public Func<TData, bool> DataFilter { get; set; }

        /// <summary>
        /// 处理数据
        /// </summary>
        internal void DataAnalysis()
        {
            //TODO:先实现功能，性能啥的，不能存在的 :p 

            var filteredData = Data.Where(x => DataFilter == null ? true : DataFilter(x)).ToList();

            //获得所有分组
            var categorys = filteredData.GroupBy(x => CategoryField(x)).Select(x => x.Key).ToList();

            BcSeriesGroup.DataAnalysis(filteredData, categorys);
        }



        #endregion

        #region 绘图

        /// <summary>
        /// 刷新显示，主要用于设置修改后用新的设置进行显示
        /// </summary>
        public void Refresh()
        {
            Drawing();
        }


        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                Drawing();
            }
        }


        /// <summary>
        /// 是否已经完成初始化，防止在在完成布局前就进行绘制，导致闪屏
        /// </summary>
        public bool IsInit { get; set; } = false;


        public void Drawing()
        {
            if (Data == null) return;

            //准备数据
            this.DataAnalysis();

            //布局元素
            BcTitle?.Drawing();
            BcLegend?.Drawing();

            BcAxisGroup?.Drawing();
            BcSeriesGroup?.Drawing();

            //初始化完成，通知绘制
            IsInit = true;

            StateHasChanged();
        }

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

        /// <summary>
        /// 字体尺寸，如果子元素没有设置尺寸，那么默认拿去此处的尺寸
        /// </summary>
        [Parameter] public int FontSize { get; set; } = 12;


        #endregion
    }
}

