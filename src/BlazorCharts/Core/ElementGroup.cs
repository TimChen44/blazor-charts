using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 元素组，集合类组件都集成他
    /// </summary>
    public class ElementGroup : Element
    {
        /// <summary>
        /// 左侧偏移
        /// </summary>
        public int OffsetX => base.X;

        /// <summary>
        /// 顶部偏移
        /// </summary>
        public int OffsetY => base.Y;

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
