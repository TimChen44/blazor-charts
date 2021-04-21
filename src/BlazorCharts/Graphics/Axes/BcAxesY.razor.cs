using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcAxesY<TData> : ElementAxes<TData>
    {
        /// <summary>
        /// Y轴摆放的位置
        /// </summary>
        public AxesYPosition Position { get; set; } = AxesYPosition.Left;

        public override void InitLayout()
        {
            Rect.X = 0;
            Rect.Y = AxisGroup.Rect.T;
            var maxString = AxisGroup.AxesYMax.ToString().Length > AxisGroup.AxesYMin.ToString().Length ? AxisGroup.AxesYMax.ToString() : AxisGroup.AxesYMin.ToString();
            Rect.W = 20 + maxString.CalcWidth(FontSize) + 10;
            Rect.H = AxisGroup.Rect.H;



            base.InitLayout();
        }

    }

    public enum AxesYPosition
    {
        Left,
        Right,
    }
}
