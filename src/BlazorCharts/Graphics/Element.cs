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
    public abstract class Element<C> : ComponentBase
    {
        public Rect Rect { get; set; } = new Rect();

        /// <summary>
        /// 配置文件
        /// </summary>
        public abstract C Config { get; }

        /// <summary>
        /// 图表对象
        /// </summary>
        [CascadingParameter] public BcChart Chart { get; set; }

        /// <summary>
        /// 是否已经完成初始化
        /// </summary>
        public bool IsInited { get; set; } = false;

        /// <summary>
        /// 更新布局，用于计算各部件占用的位置
        /// </summary>
        public abstract void UpdateLayout();

        /// <summary>
        /// 跟新数据，用于刷新界面的显示
        /// </summary>
        public abstract void UpdateData();
    }
}
