using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 元素，所有组件都继承于此
    /// </summary>
    public class Element: ComponentBase
    {
        /// <summary>
        /// X轴坐标
        /// </summary>
        [Parameter] public int X { get; set; }

        /// <summary>
        /// Y轴坐标
        /// </summary>
        [Parameter] public int Y { get; set; }
    }
}
