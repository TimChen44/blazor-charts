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
        public List<CategoryData> CategoryDatas { get; set; } = new List<CategoryData>();
        /// <summary>
        /// 系列拥有的组
        /// </summary>
        public List<string> Groups { get; set; } = new List<string>();

        /// <summary>
        /// 系列中的值
        /// </summary>
        public List<SeriesValue> SeriesValues { get; set; } = new List<SeriesValue>();

        /// <summary>
        /// 获得具体值
        /// </summary>
        /// <param name="category"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public T GetValueData<T>(string category, string group) where T: IValueData
        {
            var value = SeriesValues.FirstOrDefault(x => x.Category == category && x.Group == group);
            if (value == null) return (T)IValueData.DefaultValueData;
            return (T)value.Data;
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


    /// <summary>
    /// 分类数据
    /// </summary>
    public class CategoryData
    {
        public string Name { get; set; }

        /// <summary>
        /// 分类在轴上的位置比，真实值需要乘以轴的长度
        /// </summary>
        public double ZeroOffsetRatio { get; set; }
    }
}
