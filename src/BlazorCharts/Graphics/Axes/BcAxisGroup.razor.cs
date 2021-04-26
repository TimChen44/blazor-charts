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
            Console.WriteLine("BcSeriesGroup");
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
      
            Rect.Y = Chart.BcTitle?.Rect.B ?? 0;
            Rect.X = 0;
            Rect.W = Chart.Width-Chart.BcLegend.Rect.W;//TODO:目前先假设图例始终在右边
            Rect.H = Chart.Height - Rect.Y;

            AxesYLeft?.InitLayout();
            AxesYRight?.InitLayout();

            AxesX?.InitLayout();

            //微调X轴和Y轴，去除重复区域
            AxesYLeft.Rect.H = AxesX.Rect.Y - AxesYLeft.Rect.Y;
            AxesX.Rect.X = AxesYLeft.Rect.W;
            AxesX.Rect.W = AxesX.Rect.W - AxesYLeft.Rect.W;

            base.InitLayout();
        }
    }

}
