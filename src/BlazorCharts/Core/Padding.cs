using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 元素内部四周预留空间
    /// </summary>
    public class Padding
    {
        public Padding(int padding=0)
        {
            L = padding;
            T = padding;
            R = padding;
            B = padding;
        }


        public Padding(int left, int top, int right, int bottom)
        {
            L = left;
            T = top;
            R = right;
            B = bottom;
        }


        /// <summary>
        /// 上
        /// </summary>
        public int T { get; set; }
        /// <summary>
        /// 左
        /// </summary>
        public int L { get; set; }

        /// <summary>
        /// 右
        /// </summary>
        public int R { get; set; }
        /// <summary>
        /// 下
        /// </summary>
        public int B { get; set; }
    }
}
