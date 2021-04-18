using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcLegend<TData> : Element<TData>
    {
        public LegendPosition Position { get; set; } = LegendPosition.Right;

        public override void Init()
        {

        }
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
