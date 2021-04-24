using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public static class ColorExtensions
    {
        /// <summary>
        /// 根据名称的MD5分配颜色
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color RandomColor(this string value)
        {
            var r = new Random();
            return  Color.FromArgb(r.Next(255), r.Next(255), r.Next(255));
            //TODO:不知道为啥，浏览器尽然不支持MD5了，需要查一下资料他的替代品
            //using (var md5 = MD5.Create())
            //{
            //    var result = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            //    return Color.FromArgb(
            //        result[0] < 30 ? result[0] * 2 : result[0],
            //        result[1] < 30 ? result[1] * 2 : result[1],
            //        result[2] < 30 ? result[2] * 2 : result[2]);//防止颜色过深，不好看，将来可以做跟好的调色策略

            //}
        }

        /// <summary>
        /// 加深颜色，用于边框
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color Deepen(this Color value)
        {
            return Color.FromArgb(value.R - (value.R / 2), value.G - (value.G / 2), value.B - (value.B / 2));
        }

        /// <summary>
        /// 加亮颜色，用于高亮
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Color Highlight(this Color value)
        {
            return Color.FromArgb(value.R + ((255-value.R) / 2), value.G + ((255 - value.G) / 2), value.B + ((255 - value.B) / 2));
        }

        /// <summary>
        /// 转换成html需要的格式
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToHtml(this Color value)
        {
            return $"rgb({value.R} {value.G} {value.B} / {Math.Round((double)value.A / 255, 2)})";
        }
    }
}
