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
    public abstract class Element<C> : ComponentBase
    {
        /// <summary>
        /// X轴坐标
        /// </summary>
        [Parameter] public int X { get; set; }

        /// <summary>
        /// Y轴坐标
        /// </summary>
        [Parameter] public int Y { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        [Parameter] public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Parameter] public int Height { get; set; }

        /// <summary>
        /// 配置文件
        /// </summary>
        public abstract C Config { get; }

        /// <summary>
        /// 图表对象
        /// </summary>
        [CascadingParameter] public BcChart Chart { get; set; }
    }
}
