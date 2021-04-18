using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcChart
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

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
        public BcTitle BcTitle { get; set; }

        /// <summary>
        /// 图例
        /// </summary>
        public BcLegend BcLegend { get; set; }

        /// <summary>
        /// 图表
        /// </summary>
        public BcSeriesGroup BcSeriesGroup { get; set; }

        public void AddElement(Element element)
        {
            switch (element)
            {
                case BcTitle bcTitle:
                    BcTitle = bcTitle;
                    break;
                case BcLegend bcLegend:
                    BcLegend = bcLegend;
                    break;
                case BcSeriesGroup bcSeriesGroup:
                    BcSeriesGroup = bcSeriesGroup;
                    break;
            }
        }

        #endregion


        protected override void OnAfterRender(bool firstRender)
        {
 
        }


    }
}

