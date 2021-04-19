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
        /// 初始布局，主要用于确定各组件的位置和大小
        /// </summary>
        public virtual void InitLayout() { }

        public virtual void UpdateDisplay() { }
    }

}
