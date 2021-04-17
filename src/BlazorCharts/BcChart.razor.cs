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

        #region 元素配置

        [Parameter] public BcTitle TitleConfig { get; set; }

        [Parameter] public BcLegend LegendConfig { get; set; }

        public void AddConfig(BcConfig config)
        {
            switch (config)
            {
                case BcTitle bcTitle: 
                    TitleConfig = bcTitle; 
                    break;
                case BcLegend bcLegend:
                    LegendConfig = bcLegend;
                    break;
            }
        }

        #endregion




        [Parameter] public RenderFragment ChildContent { get; set; }


    }
}

