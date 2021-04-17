using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public abstract class BcConfig : ComponentBase
    {
        [CascadingParameter] public BcChart BcChart { get; set; }

        protected override void OnInitialized()
        {
            this.BcChart.AddConfig(this);
            base.OnInitialized();
        }
    }


}
