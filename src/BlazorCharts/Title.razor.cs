using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class Title : Element<BcTitle>
    {
        public Title()
        {

        }

        /// <summary>
        /// 从写配置
        /// </summary>
        public override BcTitle Config => Chart?.TitleConfig;
        /// <summary>
        /// 是否已经完成初始化
        /// </summary>
        public bool IsInited { get; set; } = false;

        #region 文本属性

        /// <summary>
        /// 字体大小
        /// </summary>
        public int FontSize => Chart?.TitleConfig.FontSize ?? 20;

        public TextAnchor TextAnchor => Chart?.TitleConfig.TextAnchor ?? TextAnchor.middle;

        /// <summary>
        /// 标题X坐标
        /// text元素定位是按照文字底部中间为原点，所以要做一些转换
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

        public override void UpdateLayout()
        {
            Rect.Point.X = 0;
            Rect.Point.Y = 0;
            Rect.Size.W = Chart.Width;
            Rect.Size.H = FontSize * 2;
        }

        public override void UpdateData()
        {

            IsInited = true;
        }


    }
}
