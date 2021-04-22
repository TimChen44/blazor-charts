using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcTitle<TData> : Element<TData>
    {
        public BcTitle()
        {
            FontSize = 20;
        }

        #region 文本属性

        /// <summary>
        /// 标题
        /// </summary>
        [Parameter] public string Title { get; set; }

        /// <summary>
        /// 文本位置
        /// </summary>
        public TextAnchor TextAnchor { get; set; } = TextAnchor.Middle;

        /// <summary>
        /// 标题X坐标
        /// 更具文字对其方式需要做调整
        /// </summary>
        public int TitleX
        {
            get
            {
                return Rect.C;
            }
        }

        /// <summary>
        /// 标题Y坐标
        /// </summary>
        public int TitleY
        {
            get
            {
                return Rect.M + FontSize / 2;
            }
        }

    
        #endregion

        protected override void OnInitialized()
        {

            base.OnInitialized();
        }
        public override void InitLayout()
        {
            Rect.Point.X = 0;
            Rect.Point.Y = 0;
            Rect.Size.W = Chart.Width;
            Rect.Size.H = FontSize * 3;

            base.InitLayout();
        }


    }



}
