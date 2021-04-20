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



            base.InitLayout();
        }

    }

    public enum AxesYPosition
    {
        Left,
        Right,
    }
}
