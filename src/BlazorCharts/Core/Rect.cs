using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public class Rect
    {
        /// <summary>
        /// 坐标点
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public Size Size { get; set; }
    }

    public class Point
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

    public class Size
    {
        /// <summary>
        /// 宽度
        /// </summary>
        [Parameter] public int Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        [Parameter] public int Height { get; set; }

    }
}
