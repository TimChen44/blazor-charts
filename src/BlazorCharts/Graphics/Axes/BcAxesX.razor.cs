using BlazorCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcAxesX<TData> : ElementAxes<TData>
    {

        public override void InitLayout()
        {
            Rect.H = 10 + FontSize + 20;
            Rect.X = AxisGroup.Rect.X;
            Rect.W = AxisGroup.Rect.W;
            Rect.B = AxisGroup.Rect.B;

            base.InitLayout();
        }
    }
}
