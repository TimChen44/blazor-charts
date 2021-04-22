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

        public override void InitLayout()
        {
            //先假设只放在右边,且此处代码糟糕无比，先用着

            var maxLenght = Chart.BcSeriesGroup.Series.Max(x => x.Caption.Length);
            var maxString = Chart.BcSeriesGroup.Series.First(x => x.Caption.Length == maxLenght).Caption;

            Rect.W = FontSize + FontSize + FontSize/2 + maxString.CalcWidth(FontSize) + FontSize;
            Rect.H = (FontSize * 2) * Chart.BcSeriesGroup.Series.Count;
            Rect.R = Chart.Width;
            Rect.M = (Chart.Height - Chart.BcTitle.Rect.H) / 2;
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
