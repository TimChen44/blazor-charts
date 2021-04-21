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
        /// 从数据中分析出的分组
        /// </summary>
        public List<string> CategoryValues { get; set; } = new List<string>();

        /// <summary>
        /// 每一个分组在X轴上的位置
        /// </summary>
        public Dictionary<string, int> CategoryPositions { get; set; } = new Dictionary<string, int>();


        /// <summary>
        /// Y轴最大值
        /// </summary>
        public double AxesYMax { get; set; }
        /// <summary>
        /// Y轴最小值
        /// </summary>
        public double AxesYMin { get; set; }//TODO:如果最小值存在复数是有用，先假设不存在负数


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
            //TODO:有了图例后，需要加入图例坐标计算
            Rect.Y = Chart.BcTitle?.Rect.B ?? 0;
            Rect.X = 0;
            Rect.W = Chart.Width;
            Rect.H = Chart.Height - Rect.Y;

            AxesYLeft?.InitLayout();
            AxesYRight?.InitLayout();

            AxesX?.InitLayout();

            //计算分组在X轴上的位置
            for (int i = 0; i < CategoryValues.Count; i++)
            {
                //为了解决无法评分时，增量误差，所以每个位置都重新计算
                CategoryPositions.Add(CategoryValues[i], (int)Math.Round(((double)(AxesX.Rect.W - AxesYLeft.Rect.W)) / (CategoryValues.Count + 1) * (i + 1), 0));
            }
        }
    }
}
