using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public static class StringExtensions
    {
        public static int CalcWidth(this string value, int fontSize)
        {
            var length = value.Length + Regex.Matches(value, @"[\u4e00-\u9fa5]").Count;
            return (int)Math.Ceiling((double)length / 2.0 * fontSize);
        }


    }
}
