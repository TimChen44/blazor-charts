using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 文本对齐
    /// </summary>
    public enum TextAnchor
    {
        [Description("start")]
        Start,
        [Description("middle")]
        Middle,
        [Description("end")]
        End,
        [Description("inherit")]
        Inherit,

    }
}
