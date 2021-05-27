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
    //标签配置
    public partial class BcLabels<TData> : ElementChart<TData>
    {
        /// <summary>
        /// 文本锚点
        /// </summary>
        [Display(Name = "文本锚点")]
        [Parameter] public TextAnchor TextAnchor { get; set; } = TextAnchor.Middle;
    }
}
