using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 元素，所有组件都继承于此
    /// </summary>
    public abstract class Element<TData> : ComponentBase
    {
        /// <summary>
        /// 位置大小坐标
        /// </summary>
        public Rect Rect { get; set; } = new Rect();

        protected override void OnInitialized()
        {
            this.Chart?.AddElement(this);
            base.OnInitialized();
        }

        /// <summary>
        /// 图表对象
        /// </summary>
        [CascadingParameter] public BcChart<TData> Chart { get; set; }


        /// <summary>
        /// 隐藏元素，多数情况下隐藏只是不占用控件和不显示，但是内部示例依旧创建，用于其他元素计算位置时引用
        /// </summary>
        public bool Visible { get; set; } = true;


        #region 对外属性

        private int? fontSize;
        /// <summary>
        /// 字体大小
        /// </summary>
        [Parameter]
        public int FontSize
        {
            get => fontSize ?? Chart.FontSize; 
            set => fontSize = value;
        }

        /// <summary>
        /// 字体完整高度，因为字体高度仅包含书写线以上部分，比如g下面的勾不在高度中计算
        /// </summary>
        protected int FontSizeHeight => FontSize + (int)(FontSize * 0.2);

        #endregion


        /// <summary>
        /// 初始布局，主要用于确定各组件的位置和大小
        /// </summary>
        public virtual void Drawing()
        {

        }

        public virtual void UpdateDisplay() { }
    }

}
