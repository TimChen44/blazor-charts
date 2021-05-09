using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    /// <summary>
    /// 图表元素对象基类
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public abstract class ElementChart<TData> : Element<TData>
    {
        public  Rect PaddingRect => new Rect(Padding, Rect);


        private Padding _Padding;
        /// <summary>
        /// 边框内部距离
        /// </summary>
        [Parameter]
        public Padding Padding
        {
            get
            {
                if (_Padding == null) _Padding = new Padding(5);
                return _Padding;
            }
            set => _Padding = value;
        }
        /// <summary>
        ///边框左部距离
        /// </summary>
        [Parameter] public int PaddingLeft { get => Padding.L; set => Padding.L = value; }
        /// <summary>
        ///边框上部距离
        /// </summary>
        [Parameter] public int PaddingTop { get => Padding.T; set => Padding.T = value; }
        /// <summary>
        ///边框右部距离
        /// </summary>
        [Parameter] public int PaddingRight { get => Padding.R; set => Padding.R = value; }
        /// <summary>
        ///边框下部距离
        /// </summary>
        [Parameter] public int PaddingBottom { get => Padding.B; set => Padding.B = value; }
    }
}
