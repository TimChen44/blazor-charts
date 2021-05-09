﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class BcColumnSeries<TData> : ElementSeries<TData>
    {
        /// <summary>
        /// 顺序号，多个柱状图需要合理排序
        /// </summary>
        public int SequenceNumber { get; set; } = 0;


        public BcColumnSeries() : base(SeriesType.Column)
        {

        }

        public override void Drawing()
        {
            //给柱状图进行编号
            //如果有多个柱状图存在多次重复执行的问题，性能影响很小，所以以后再说
            var sn = 1;
            foreach (BcColumnSeries<TData> item in Chart.BcSeriesGroup.Series.Where(x => x is BcColumnSeries<TData>))
            {
                item.SequenceNumber = sn;
                sn++;
            }
            
            base.Drawing();
        }
    }
}