using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcLegend<TData> : ElementChart<TData>
    {
        /// <summary>
        /// 图例位置
        /// </summary>
        [Parameter] public LegendPosition Position { get; set; } = LegendPosition.Right;

        /// <summary>
        /// 边框宽度
        /// </summary>
        [Parameter] public int BorderWidth { get; set; } = 0;
        /// <summary>
        /// 边框颜色
        /// </summary>
        [Parameter] public string BorderColor { get; set; }

        public int? _ItemSpacing;
        /// <summary>
        /// 项目之间的间距
        /// </summary>
        [Parameter] public int ItemSpacing { get => _ItemSpacing ?? FontSize / 2; set => _ItemSpacing = value; }

        public BcLegend()
        {
            Padding = new Padding(5);
        }

        /// <summary>
        /// 单个项目的大小
        /// </summary>
        private Size _ItemSize;
        /// <summary>
        /// 项目排版方向 Row,Col
        /// </summary>
        private string _ItemDirection;

        public override void Drawing()
        {

            var groupNames = Chart.BcSeriesGroup.GroupNames;

            //先算出最大的文本
            var maxString = "";
            foreach (var item in groupNames)
            {
                if (item.Length > maxString.Length)
                    maxString = item;
            }

            _ItemSize = new Size(maxString.CalcWidth(FontSize) + FontSize + FontSize / 2 + ItemSpacing, FontSize + ItemSpacing);

            //设置图例框的大小
            switch (Position)
            {
                case LegendPosition.Left:
                case LegendPosition.LeftTop:
                case LegendPosition.LeftBottom:
                case LegendPosition.Right:
                case LegendPosition.RightTop:
                case LegendPosition.RightBottom:
                    Rect.W = Padding.L + _ItemSize.W + Padding.R + BorderWidth * 2;
                    Rect.H = Padding.T + _ItemSize.H * groupNames.Count + Padding.B + BorderWidth * 2;
                    _ItemDirection = "Col";
                    break;

                case LegendPosition.Top:
                case LegendPosition.Bottom:
                    Rect.W = Padding.L + _ItemSize.W * groupNames.Count + Padding.R + BorderWidth * 2;
                    Rect.H = Padding.T + _ItemSize.H + Padding.B + BorderWidth * 2;
                    _ItemDirection = "Row";
                    break;
            }

            Rect.X = Position switch
            {
                LegendPosition.Left => 0,
                LegendPosition.LeftTop => 0,
                LegendPosition.LeftBottom => 0,
                LegendPosition.Right => Chart.Width - Rect.W,
                LegendPosition.RightTop => Chart.Width - Rect.W,
                LegendPosition.RightBottom => Chart.Width - Rect.W,
                LegendPosition.Top => Chart.Width / 2 - Rect.W / 2,
                LegendPosition.Bottom => Chart.Width / 2 - Rect.W / 2,
                _ => throw new NotImplementedException(),
            };

            Rect.Y = Position switch
            {
                LegendPosition.Top => Chart.BcTitle.Rect.B,
                LegendPosition.LeftTop => Chart.BcTitle.Rect.B,
                LegendPosition.RightTop => Chart.BcTitle.Rect.B,
                LegendPosition.Bottom => Chart.Height - Rect.H,
                LegendPosition.LeftBottom => Chart.Height - Rect.H,
                LegendPosition.RightBottom => Chart.Height - Rect.H,
                LegendPosition.Left => Chart.Height / 2 - Rect.H / 2,
                LegendPosition.Right => Chart.Height / 2 - Rect.H / 2,
                _ => throw new NotImplementedException(),
            };
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
