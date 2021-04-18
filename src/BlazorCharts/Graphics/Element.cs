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
        public Rect Rect { get; set; } = new Rect();

        protected override void OnInitialized()
        {
            this.Chart.AddElement(this);
            base.OnInitialized();
        }

        /// <summary>
        /// 图表对象
        /// </summary>
        [CascadingParameter] public BcChart<TData> Chart { get; set; }

        public bool Visible { get; set; } = true;

        /// <summary>
        /// 初始化函数
        /// 此处不使用OnInitialized的原因是应为组件被加入到BcChart的顺序不可控，但是位置计算需要根据顺序进行，所以专门做了初始化方法
        /// </summary>
        public abstract void Init();


    }
}
