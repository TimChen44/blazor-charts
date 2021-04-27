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
            Rect.X = AxisGroup.Rect.X;
            Rect.Y = AxisGroup.Rect.T;

            var max = Chart.SeriesDatas.Max(x => x.Max);
            var min = Chart.SeriesDatas.Min(x => x.Min);

            var maxString = max.ToString().Length > min.ToString().Length ? max.ToString() : min.ToString();
            Rect.W = 20 + maxString.CalcWidth(FontSize) + 10;
            Rect.H = AxisGroup.Rect.H;
         
            AxesYMax = max;

            //TODO:此处还缺少考虑复数
            base.InitLayout();
        }

        public double AxesYMax { get; set; }

        /// <summary>
        /// 根据值或者这个值在X轴的高度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetHeightByValue(double value)
        {
            return (int)Math.Round((double)value / AxesYMax * Rect.H, 0);
        }
    }

    public enum AxesYPosition
    {
        Left,
        Right,
    }
}
