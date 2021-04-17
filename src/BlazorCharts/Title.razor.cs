using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class Title : ElementGroup
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Text => BcChart?.BcTitle?.Title;

        [CascadingParameter] public BcChart BcChart { get; set; }

    }
}
