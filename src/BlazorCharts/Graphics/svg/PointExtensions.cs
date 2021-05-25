using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
   public static class PointExtensions
    {
        /// <summary>
        /// 坐标转svg格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPoints(this List<Point> value)
        {
            if (value.Count==0) return "";
            return value.Select(x => x.ToPoint()).Aggregate((a, b) => a + " " + b);
        }
    }
}
