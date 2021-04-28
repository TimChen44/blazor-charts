using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts.Docs.Shared
{
    /// <summary>
    /// 示例数据
    /// </summary>
    static class DemoData
    {
        public static List<Github> Githubs = new List<Github>()
        {
            new Github(){Year=2017,View =2500,Start=800,Fork=400},
            new Github(){Year=2018,View =2200,Start=900,Fork=800},
            new Github(){Year=2019,View =2800,Start=1100,Fork=700},
            new Github(){Year=2020,View =2600,Start=1400,Fork=900},
        };
    }
    public class Github
    {
        public int Year { get; set; }
        public int View { get; set; }
        public int Start { get; set; }
        public int Fork { get; set; }
    }
}
