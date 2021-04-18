using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class Legend : Element<BcLegend>
    {        /// <summary>
             /// 从写配置
             /// </summary>
        public override BcLegend Config => Chart?.LegendConfig;

        public override void UpdateData()
        {
            
        }

        public override void UpdateLayout()
        {
            
        }
    }
}
