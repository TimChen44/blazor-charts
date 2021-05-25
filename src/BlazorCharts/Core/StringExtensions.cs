using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public static class StringExtensions
    {
        /// <summary>
        /// 计算文本的宽度
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        public static int CalcWidth(this string value, int fontSize)
        {
            var length = value.Length + Regex.Matches(value, @"[\u4e00-\u9fa5]").Count;
            return (int)Math.Ceiling((double)length / 2.0 * fontSize);
        }


    }
}
