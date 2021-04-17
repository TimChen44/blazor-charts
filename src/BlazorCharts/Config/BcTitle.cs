using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public class BcTitle : BcConfig
    {
        [Parameter] public string Title { get; set; }

    }
}
