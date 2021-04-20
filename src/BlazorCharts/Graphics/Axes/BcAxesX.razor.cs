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
            Rect.X = 0;
            Rect.Y = AxisGroup.Rect.T;

            var maxLenght = Math.Max(AxisGroup.AxesYMax.ToString().Length, AxisGroup.AxesYMin.ToString().Length).ToString();


            Rect.W = maxLenght.CalcWidth(FontSize);

            base.InitLayout();
        }
    }
}
