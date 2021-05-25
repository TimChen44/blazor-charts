using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{

    /// <summary>
    /// 数据源接口
    /// </summary>
    public class DataSourceBase<TData> : ComponentBase
    {
        /// <summary>
        /// 图表对象
        /// </summary>
        [CascadingParameter] public BcChart<TData> Chart { get; set; }

        protected override void OnInitialized()
        {
            this.Chart?.AddElement(this);
            base.OnInitialized();
        }




    }


}
