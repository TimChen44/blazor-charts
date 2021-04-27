using BlazorCharts.Core;
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
    public partial class BcLegend<TData> : Element<TData>
    {
        /// <summary>
        /// 图例位置
        /// </summary>
        [Parameter] public LegendPosition Position { get; set; } = LegendPosition.Right;

        /// <summary>
        /// 边框内部距离
        /// </summary>
        [Parameter] public Padding Padding { get; set; } = new Padding(5);
        /// <summary>
        ///边框左部距离
        /// </summary>
        [Parameter] public int PaddingLeft { get => Padding.L; set => Padding.L = value; }
        /// <summary>
        ///边框上部距离
        /// </summary>
        [Parameter] public int PaddingTop { get => Padding.T; set => Padding.T = value; }
        /// <summary>
        ///边框右部距离
        /// </summary>
        [Parameter] public int PaddingRight { get => Padding.R; set => Padding.R = value; }
        /// <summary>
        ///边框下部距离
        /// </summary>
        [Parameter] public int PaddingBottom { get => Padding.B; set => Padding.B = value; }

        /// <summary>
        /// 边框宽度
        /// </summary>
        [Parameter] public int BorderWidth { get; set; } = 0;
        /// <summary>
        /// 边框颜色
        /// </summary>
        [Parameter] public Color BorderColor { get; set; } = Color.Silver;

        public int? _ItemSpacing;
        /// <summary>
        /// 项目之间的间距
        /// </summary>
        [Parameter] public int ItemSpacing { get => _ItemSpacing ?? FontSize / 2; set => _ItemSpacing = value; }


        /// <summary>
        /// 单个项目的大小
        /// </summary>
        private Size _ItemSize;
        /// <summary>
        /// 项目排版方向 Row,Col
        /// </summary>
        private string _ItemDirection;

        public override void InitLayout()
        {
            //先算出最大的文本
            var maxString = "";
            foreach (var item in Chart.SeriesDatas)
            {
                if (item.SeriesName.Length > maxString.Length)
                    maxString = item.SeriesName;
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
                    Rect.W = Padding.L + _ItemSize.W + Padding.R;
                    Rect.H = Padding.T + _ItemSize.H * Chart.SeriesDatas.Count + Padding.B;
                    _ItemDirection = "Col";
                    break;

                case LegendPosition.Top:
                case LegendPosition.Bottom:
                    Rect.W = Padding.L + _ItemSize.W * Chart.SeriesDatas.Count + Padding.R;
                    Rect.H = Padding.T + _ItemSize.H + Padding.B;
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
                LegendPosition.Top => 0,
                LegendPosition.LeftTop => 0,
                LegendPosition.RightTop => 0,
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
