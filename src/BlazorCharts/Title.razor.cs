using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public partial class Title : Element<BcTitle>
    {
        public Title()
        {
            X = 100;
            Y = 100;
        }


        /// <summary>
        /// 从写配置
        /// </summary>
        public override BcTitle Config => Chart?.TitleConfig;

    }
}
