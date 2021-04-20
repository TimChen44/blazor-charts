﻿using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcSeriesGroup<TData> : Element<TData>
    {
        [Parameter] public RenderFragment ChildContent { get; set; }

        /// <summary>
        /// 图表中的系列
        /// </summary>
        public List<ElementSeries<TData>> Series { get; set; } = new List<ElementSeries<TData>>();
        public void AddSeries(ElementSeries<TData> element)
        {
            Series.Add(element);
        }


        protected override void OnInitialized()
        {
            Console.WriteLine("BcSeriesGroup");
            base.OnInitialized();
        }
        public override void InitLayout()
        {

        }

    }


}
