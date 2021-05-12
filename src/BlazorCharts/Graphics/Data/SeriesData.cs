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
        public List<string> Categories { get; set; } = new List<string>();

        public List<string> Groups { get; set; } = new List<string>();

        public Dictionary<string, CategoryData> CategoryDatas { get; set; } = new Dictionary<string, CategoryData>();

        /// <summary>
        /// 获得具体值
        /// </summary>
        /// <param name="category"></param>
        /// <param name="group"></param>
        /// <returns></returns>
        public IValueData GetGroupData(string category, string group)
        {
            CategoryDatas.TryGetValue(category, out var categoryData);
            if (categoryData == null) return IValueData.DefaultValueData;

            categoryData.GroupDatas.TryGetValue(group, out var groupData);
            if (groupData == null) return IValueData.DefaultValueData;

            return groupData.Data;
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


    public class CategoryData
    {
        public CategoryData(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        public Dictionary<string, GroupData> GroupDatas { get; set; } = new Dictionary<string, GroupData>();

    }

    public class GroupData
    {
        public GroupData(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 组名称
        /// </summary>
        public string Name { get; set; }

        public IValueData Data { get; set; }
    }


}
