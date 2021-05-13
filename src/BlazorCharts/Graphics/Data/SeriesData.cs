using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    /// <summary>
    /// 系列数据，一个系列中的数据存储于此
    /// </summary>
    public class SeriesData
    {
        /// <summary>
        /// 系列拥有的分类
        /// </summary>
        public List<string> Categories { get; set; } = new List<string>();
        /// <summary>
        /// 系列拥有的组
        /// </summary>
        public List<string> Groups { get; set; } = new List<string>();

        /// <summary>
        /// 系列中的值
        /// </summary>
        public List<SeriesValue> SeriesValues = new List<SeriesValue>();

        /// <summary>
        /// 获得具体值
        /// </summary>
        /// <param name="category"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public IValueData GetGroupData(string category, string group)
        {
            var value = SeriesValues.FirstOrDefault(x => x.Category == category && x.Group == group);
            if (value == null) return IValueData.DefaultValueData;
            return value.Data;
        }


        /// <summary>
        /// 最大值：用于计算坐标轴
        /// </summary>
        public double MaxValue { get; set; }

        /// <summary>
        /// 最小值：用于计算坐标轴
        /// </summary>
        public double MinValue { get; set; }

    }


    public class SeriesValue
    {
        public SeriesValue(string category, string group)
        {
            Category = category;
            Group = group;
        }

        public string Category { get; set; }
        public string Group { get; set; }
        public IValueData Data { get; set; }
    }
}
