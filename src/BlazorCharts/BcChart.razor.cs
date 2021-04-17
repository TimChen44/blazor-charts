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
        /// <summary>
        /// 宽度
        /// </summary>
        [Parameter] public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Parameter] public int Height { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Parameter] public BcTitle BcTitle { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public void AddBcE(BcTitle bce)
        {
            BcTitle = bce;
        }
    }
}

