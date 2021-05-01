using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
            var result = CRC32Cls.GetCRC32Str(value);
            byte r = Convert.ToByte(result % 255);
            byte g = Convert.ToByte(result / 255 % 255);
            byte b = Convert.ToByte(result / 255 / 255 % 255);

            return Color.FromArgb(
                r < 90 ? r + 90 : r,
                g < 90 ? g + 90 : g,
                b < 90 ? b + 90 : b);//防止颜色过深，不好看，将来可以做跟好的调色策略

            //TODO:Wasm尽然不支持MD5了T_T，详情：https://docs.microsoft.com/zh-cn/dotnet/core/compatibility/cryptography/5.0/cryptography-apis-not-supported-on-blazor-webassembly
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
            return Color.FromArgb(value.R + ((255 - value.R) / 2), value.G + ((255 - value.G) / 2), value.B + ((255 - value.B) / 2));
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


    /// <summary>
    /// CRC校验
    /// 应为Wams 在.net5不支持System.Security.Cryptography，所以临时找了一个CRC来抽数
    /// </summary>
    class CRC32Cls
    {
        static protected ulong[] Crc32Table;
        //生成CRC32码表
        static public void GetCRC32Table()
        {
            ulong Crc;
            Crc32Table = new ulong[256];
            int i, j;
            for (i = 0; i < 256; i++)
            {
                Crc = (ulong)i;
                for (j = 8; j > 0; j--)
                {
                    if ((Crc & 1) == 1)
                        Crc = (Crc >> 1) ^ 0xEDB88320;
                    else
                        Crc >>= 1;
                }
                Crc32Table[i] = Crc;
            }
        }
        //获取字符串的CRC32校验值
        static public ulong GetCRC32Str(string sInputString)
        {
            //生成码表
            GetCRC32Table();
            byte[] buffer = System.Text.ASCIIEncoding.ASCII.GetBytes(sInputString); ulong value = 0xffffffff;
            int len = buffer.Length;
            for (int i = 0; i < len; i++)
            {
                value = (value >> 8) ^ Crc32Table[(value & 0xFF) ^ buffer[i]];
            }
            return value ^ 0xffffffff;
        }
    }

}

