using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public class BcTitle : ComponentBase
    {
        [Parameter] public string Title { get; set; }

        [CascadingParameter] public BcChart BcChart { get; set; }

        protected override void OnInitialized()
        {
            this.BcChart.AddBcE(this);
            base.OnInitialized();
        }
    }
}
