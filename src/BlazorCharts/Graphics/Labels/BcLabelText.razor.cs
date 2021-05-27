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
    partial class BcLabelText<TData>
    {
        /// <summary>
        /// 图表对象
        /// </summary>
        [CascadingParameter] public BcChart<TData> Chart { get; set; }

        public BcLabels<TData> BcLabels => Chart.BcLabels;

        /// <summary>
        /// 真实的值
        /// </summary>
        [Display(Name = "真实的值")]
        [Parameter] public double Value { get; set; }

        /// <summary>
        /// 格式化显示内容
        /// </summary>
        [Display(Name = "格式化显示内容")]
        [Parameter] public Func<double, string> Formate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "显示文本的锚点X")]
        [Parameter] public int AnchorX { get; set; }

        [Display(Name = "显示文本的锚点Y")]
        [Parameter] public int AnchorY { get; set; }

        /// <summary>
        /// 显示的值
        /// </summary>
        public string DisplayText
        {
            get
            {
                if (Formate == null)
                    return Value.ToString();
                else
                    return Formate(Value).ToString();
            }
        }

        public int FontSize => BcLabels?.FontSize ?? Chart.FontSize;

        /// <summary>
        /// 字体完整高度，因为字体高度仅包含书写线以上部分，比如g下面的勾不在高度中计算
        /// </summary>
        protected int FontSizeHeight => FontSize + (int)(FontSize * 0.2);



    }
}