using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcChart<TData>
    {
        [Display(Name = "子内容", Description = "标题，图例，系列等图表元素放置于此")]
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

        /// <summary>
        /// 数据源
        /// </summary>
        public DataSourceBase<TData> DataSource { get; set; }

        public void AddElement(ComponentBase element)
        {
            switch (element)
            {
                case BcTitle<TData> bcTitle:
                    BcTitle = bcTitle; break;
                case BcLegend<TData> bcLegend:
                    if (BcLegend == null) BcLegend = bcLegend;
                    break;
                case BcSeriesGroup<TData> bcSeriesGroup:
                    BcSeriesGroup = bcSeriesGroup; break;
                case ElementSeries<TData> bcElementSeries:
                    BcSeriesGroup.AddSeries(bcElementSeries); break;
                case BcAxisGroup<TData> bcAxisGroup:
                    BcAxisGroup = bcAxisGroup; break;
                case ElementAxes<TData> axes:
                    BcAxisGroup.AddAxes(axes); break;
                case DataSourceBase<TData> dataSource:
                    if (DataSource == null) DataSource = dataSource; break;
            }
        }

        #endregion

        #region 数据


        /// <summary>
        /// 数据
        /// </summary>
        [Display(Name = "数据集合")]
        [Parameter]
        public IEnumerable<TData> Data
        {
            get => RealData;
            set => DataChange(value);
        }

        /// <summary>
        /// 轴（类别）字段
        /// </summary>
        [Display(Name = "轴（类别）字段", Description = "通过一个方法来定义图表的分类")]
        [Parameter] public Func<TData, string> CategoryField { get; set; }

        /// <summary>
        /// 数据筛选：可以通过它筛选数据
        /// </summary>
        [Display(Name = "数据筛选", Description = "可以通过它筛选数据")]
        [Parameter] public Func<TData, bool> DataFilter { get; set; }


        [Display(Name = "图表数据")]
        internal IEnumerable<TData> RealData { get; set; }

        /// <summary>
        /// 更新数据方法，用于DataSourceBase来调用
        /// </summary>
        internal void DataChange(IEnumerable<TData> data)
        {
            //如果hash值一样就不进行更新，这位了避免循环更行调用的问题
            //所以暂时无法跟踪列表中数值修改
            var newDataHashCode = data?.GetHashCode() ?? 0;
            if (newDataHashCode != currentDataHashCode)
            {
                currentDataHashCode = newDataHashCode;
                RealData = data;
                if (IsRendered == true)
                {//只有完成显示后修改数据才触发重绘
                    Refresh();
                }
            }
        }
        // 当前数据的hash值
        int currentDataHashCode;

        /// <summary>
        /// 处理数据
        /// </summary>
        internal void DataAnalysis()
        {
            if (RealData == null) return;

            var filteredData = RealData.Where(x => DataFilter == null ? true : DataFilter(x)).ToList();
            //获得所有分组
            var categorys = filteredData.GroupBy(x => CategoryField(x)).Select(x => x.Key).ToList();

            BcSeriesGroup.DataAnalysis(filteredData, categorys);
        }

        #endregion

        #region 绘图

        /// <summary>
        /// 刷新图表，用于数据更新了重新更新图表
        /// </summary>
        public void Refresh()
        {
            DataAnalysis();
            Repaint();
        }

        bool IsRendered = false;
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                DataAnalysis();
                Repaint();

                IsRendered = true;
            }
        }

        /// <summary>
        /// 是否已经完成初始化，防止在在完成布局前就进行绘制，导致闪屏
        /// </summary>
        internal bool IsInit { get; set; } = false;

        /// <summary>
        /// 重新绘制图表，用于图表配置已修改，数据没修改
        /// </summary>
        public void Repaint()
        {
            if (RealData == null) return;

            //布局元素
            BcTitle?.Drawing();
            BcLegend?.Drawing();

            BcAxisGroup?.Drawing();
            BcSeriesGroup?.Drawing();

            //初始化完成，通知绘制
            IsInit = true;//TODO:初始化完成机制需要再优化

            StateHasChanged();
        }

        #endregion

        #region 图表属性

        /// <summary>
        /// 宽度
        /// </summary>
        [Display(Name = "宽度")]
        [Parameter] public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Display(Name = "高度")]
        [Parameter] public int Height { get; set; }

        /// <summary>
        /// 字体尺寸，如果子元素没有设置尺寸，默认使用此尺寸
        /// </summary>
        [Display(Name = "字体尺寸", Description = "如果子元素没有设置尺寸，默认使用此尺寸")]
        [Parameter] public int FontSize { get; set; } = 12;


        #endregion
    }
}

