using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcAxisGroup<TData> : Element<TData>
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        /// <summary>
        /// X横
        /// </summary>
        public BcAxesX<TData> AxesX { get; set; }

        /// <summary>
        /// Y轴左侧
        /// </summary>
        public BcAxesY<TData> AxesYLeft { get; set; }

        /// <summary>
        /// Y轴右侧
        /// </summary>
        public BcAxesY<TData> AxesYRight { get; set; }

        public void AddAxes(ElementAxes<TData> element)
        {
            switch (element)
            {
                case BcAxesX<TData> bcAxesX:
                    AxesX = bcAxesX;
                    break;
                case BcAxesY<TData> bcAxesY when bcAxesY.Position == AxesYPosition.Left:
                    AxesYLeft = bcAxesY;
                    break;
                case BcAxesY<TData> bcAxesY when bcAxesY.Position == AxesYPosition.Right:
                    AxesYRight = bcAxesY;
                    break;
            }
            element.AxisGroup = this;
        }


        public override void InitLayout()
        {
            switch (Chart.BcLegend.Position)
            {
                case LegendPosition.Top:
                    Rect.Y = Chart.BcLegend?.Rect.B ?? 0;
                    Rect.X = 0;
                    Rect.W = Chart.Width;
                    Rect.H = Chart.Height - Rect.Y;
                    break;
                case LegendPosition.Bottom:
                    Rect.Y = Chart.BcTitle?.Rect.B ?? 0;
                    Rect.X = 0;
                    Rect.W = Chart.Width;
                    Rect.H = Chart.Height - Chart.BcLegend.Rect.H - Rect.Y;
                    break;
                case LegendPosition.Left:
                case LegendPosition.LeftTop:
                case LegendPosition.LeftBottom:
                    Rect.Y = Chart.BcTitle?.Rect.B ?? 0;
                    Rect.X = Chart.BcLegend.Rect.R;
                    Rect.W = Chart.Width - Chart.BcLegend.Rect.W;
                    Rect.H = Chart.Height - Rect.Y;
                    break;
                case LegendPosition.Right:
                case LegendPosition.RightTop:
                case LegendPosition.RightBottom:
                    Rect.Y = Chart.BcTitle?.Rect.B ?? 0;
                    Rect.X = 0;
                    Rect.W = Chart.Width - Chart.BcLegend.Rect.W;
                    Rect.H = Chart.Height - Rect.Y;
                    break;
            }

            AxesYLeft?.InitLayout();
            AxesYRight?.InitLayout();

            AxesX?.InitLayout();

            //微调X轴和Y轴，去除重复区域
            AxesYLeft.Rect.H = AxesX.Rect.Y - AxesYLeft.Rect.Y;
            AxesX.Rect.X = AxesYLeft.Rect.R;
            AxesX.Rect.W = AxesX.Rect.W - AxesYLeft.Rect.W;

            base.InitLayout();
        }
    }

}
