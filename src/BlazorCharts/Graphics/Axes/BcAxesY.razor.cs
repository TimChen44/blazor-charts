using Microsoft.AspNetCore.Components;
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

        [Parameter] public int? Step { get; set; }


        public override void Drawing()
        {
            Rect.X = AxisGroup.Rect.X;
            Rect.Y = AxisGroup.Rect.T;

            var realMax = Chart.SeriesDatas.Max(x => x.Max);
            var mrealMin = Chart.SeriesDatas.Min(x => x.Min);

            var maxString = realMax.ToString().Length > realMax.ToString().Length ? realMax.ToString() : realMax.ToString();
            Rect.W = 20 + maxString.CalcWidth(FontSize) + 10;
            Rect.H = AxisGroup.Rect.H;

            AxesYMax = Carry(realMax);

            //AxesYMax = Carry(realMax);
            //group.Min = Carry(realMin);

            //TODO:此处还缺少考虑复数
            base.Drawing();
        }


        /// <summary>
        /// 获得最大值
        /// </summary>
        /// <param name="realValue"></param>
        /// <returns></returns>
        private double Carry(double realValue)
        {
            var negative = realValue < 0;//记录当前是否是复数

            var value = Math.Abs(realValue);
            var maxLength = ((int)value).ToString().Length;
            if (maxLength == 1)
            {
                value = Math.Ceiling(value);
            }
            else if (maxLength > 1)
            {
                var carry = Math.Pow(10, (maxLength - 1));
                value = Math.Ceiling(value / carry) * carry;
            }

            if (negative) value *= -1;
            return value;

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
