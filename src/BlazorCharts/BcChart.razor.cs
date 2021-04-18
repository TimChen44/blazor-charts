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

        //标题
        private Title TitleRef { get; set; }
        [Parameter] public BcTitle TitleConfig { get; set; }

        //图例
        [Parameter] public Legend LegendRef { get; set; }
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

        public int MyProperty { get; set; }

        #endregion

        [Parameter] public RenderFragment ChildContent { get; set; }


        protected override void OnAfterRender(bool firstRender)
        {
            UpdateLayout();
            UpdateData();
        }

        public void UpdateLayout()
        {
            TitleRef.UpdateLayout();

        }

        public void UpdateData()
        {
            TitleRef.UpdateData();

            StateHasChanged();
        }

    }
}

