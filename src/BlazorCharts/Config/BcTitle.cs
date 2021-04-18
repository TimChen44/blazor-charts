using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public class BcTitle : BcConfig
    {
        [Parameter] public string Title { get; set; }

        /// <summary>
        /// 文本尺寸
        /// </summary>
        [Parameter] public int FontSize { get; set; } = 20;

        /// <summary>
        /// 文本位置
        /// </summary>
        public TextAnchor TextAnchor { get; set; }
    }

    public enum TextAnchor
    {
        [Description("Start")] 
        start,
        [Description("Middle")] 
        middle,
        [Description("End")] 
        end,
        [Description("Inherit")] 
        inherit,

    }
}
