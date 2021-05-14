using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
   public static class PointExtensions
    {
        public static string ToPoints(this List<Point> value)
        {
            if (value.Count==0) return "";
            return value.Select(x => x.ToPoint()).Aggregate((a, b) => a + " " + b);
        }
    }
}
