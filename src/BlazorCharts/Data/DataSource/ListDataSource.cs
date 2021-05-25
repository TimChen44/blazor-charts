using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public class ListDataSource<TData> : DataSourceBase<TData>
    {
        [Display(Name = "数据集合", Description = "绑定的数据集合")]
        [Parameter] public IEnumerable<TData> Data { get; set; }

        protected override void OnParametersSet()
        {
            Chart.DataChange(Data);
            base.OnParametersSet();
        }
    }
}
