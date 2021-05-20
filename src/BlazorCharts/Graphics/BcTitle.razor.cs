using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcTitle<TData> : ElementChart<TData>
    {
        public BcTitle()
        {
            FontSize = 20;
            Padding = new Padding(20);
        }


        #region 文本属性
        /// <summary>
        /// 标题
        /// </summary>
        [Display(Name = "标题")]
        [Parameter] public string Title { get; set; }

        /// <summary>
        /// 文本锚点
        /// </summary>
        [Display(Name = "文本锚点")]
        [Parameter] public TextAnchor TextAnchor { get; set; } = TextAnchor.Middle;

        /// <summary>
        /// 文本对齐
        /// </summary>
        [Display(Name = "文本对齐")]
        [Parameter] public TextAlign TextAlign { get; set; } = TextAlign.Center;

        /// <summary>
        /// 标题X坐标
        /// 更具文字对其方式需要做调整
        /// </summary>
        public int TitleX
        {
            get
            {
                return TextAlign switch
                {
                    TextAlign.Start => PaddingRect.L,
                    TextAlign.Center => PaddingRect.C,
                    TextAlign.End => PaddingRect.R,
                    _ => throw new NotImplementedException(),
                };
            }
        }

        /// <summary>
        /// 标题Y坐标
        /// </summary>
        public int TitleY
        {
            get
            {
                return FontSize + Padding.T;
            }
        }


        #endregion

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        public override void Drawing()
        {
            Rect.X = 0;
            Rect.Y = 0;
            Rect.W = Chart.Width;
            Rect.H = FontSizeHeight + Padding.T + Padding.B;

            base.Drawing();
        }


    }



}
