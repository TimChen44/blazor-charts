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

        public override void InitLayout()
        {
            //先算出最大的文本
            var maxString = "";
            foreach (var item in Chart.CategoryDatas)
            {
                if (item.Category.Length > maxString.Length)
                    maxString = item.Category;
            }
            Size fontSize = new Size(maxString.CalcWidth(FontSize), FontSize + ItemSpacing);


            Rect.W = Padding.L + fontSize.W + Padding.R;
            Rect.H = fontSize.H * Chart.SeriesDatas.Count;
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
