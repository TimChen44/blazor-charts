using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    /// <summary>
    /// 单一值
    /// </summary>
    public class SingleValueData : IValueData
    {
        public SingleValueData(double value)
        {
            Value = value;
        }
        public double Min => Value;

        public double Max => Value;

        public double Value { get; set; }
    }

    /// <summary>
    /// 区间值
    /// </summary>
    public class IntervalValueData
    {

    }

    /// <summary>
    /// 区间值
    /// </summary>
    public class KValueData
    {

    }

    public interface IValueData
    {
        /// <summary>
        /// 默认值
        /// </summary>
        public static readonly IValueData DefaultValueData = new SingleValueData() { Value = 0 };

        /// <summary>
        /// 最小值
        /// </summary>
        public double Min { get; }
        /// <summary>
        /// 最大值
        /// </summary>
        public double Max { get; }

        /// <summary>
        /// 值（不同的实现可能会不一样，以具体实现为准）
        /// </summary>
        public double Value { get; set; }

    }
}
