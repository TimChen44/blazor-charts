using Microsoft.AspNetCore.Components;
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

        protected override void OnInitialized()
        {
            Console.WriteLine("BcSeriesGroup");
            base.OnInitialized();
        }
        public override void Init()
        {

        }

    }

}
