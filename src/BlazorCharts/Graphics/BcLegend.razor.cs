using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class Legend : Element
    {
        public LegendPosition Position { get; set; } = LegendPosition.Right;

    }

    public enum LegendPosition
    {
        Left,
        Right,
        Top,
        Bottom,

        LeftTop,
        RightTop,
        LeftBottom,
        RightBottom,
    }
}
