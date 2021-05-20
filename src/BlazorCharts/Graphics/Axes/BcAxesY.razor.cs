using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    public partial class BcAxesY<TData> : ElementAxes<TData>
    {
        /// <summary>
        /// 主要单位
        /// </summary>
        [Display(Name = "主要单位的刻度")]
        [Parameter] public double? UnitsMajor { get; set; }

        /// <summary>
        /// 次要单位
        /// </summary>
        [Display(Name = "次要单位的刻度")]
        [Parameter] public double? UnitsMinor { get; set; }

        /// <summary>
        /// 显示主要网格线
        /// </summary>
        [Display(Name = "显示主要网格线")]
        [Parameter] public bool GridLineMajor { get; set; } = true;
        /// <summary>
        /// 显示次要网格线
        /// </summary>
        [Display(Name = "显示次要网格线")]
        [Parameter] public bool GridLineMinor { get; set; } = false;

        /// <summary>
        /// 标签位置
        /// </summary>
        [Display(Name = "标签位置")]
        [Parameter] public AxesLabelPosition LabelPosition { get; set; } = AxesLabelPosition.Axis;

        private int? _DistanceAxis;
        /// <summary>
        /// 与坐标轴的距离
        /// </summary>
        [Display(Name = "标签与坐标轴的距离")]
        [Parameter] public int? DistanceAxis { get => _DistanceAxis ?? 10; set => _DistanceAxis = value; }

        /// <summary>
        /// 是否是第二坐标轴
        /// </summary>
        [Display(Name = "是否是第二坐标轴")]
        [Parameter] public bool IsSecondaryAxis { get; set; }

        /// <summary>
        /// 是否可见
        /// </summary>
        [Display(Name = "可见的")]
        [Parameter] public bool Visible { get; set; } = true;

        public override void Drawing()
        {

            Rect.Y = AxisGroup.Rect.T;


            var realMax = Chart.BcSeriesGroup.Series.Where(x => x.IsSecondaryAxis == IsSecondaryAxis).Max(x => (double?)x.SeriesData.MaxValue) ?? 0;
            var realMin = Chart.BcSeriesGroup.Series.Where(x => x.IsSecondaryAxis == IsSecondaryAxis).Min(x => (double?)x.SeriesData.MinValue) ?? 0;

            AxesYMax = Carry(realMax);
            AxesYMin = realMin;

            if (Visible == true)
            {//可见的时候计算宽度
                var maxString = AxesYMax.ToString().Length > AxesYMin.ToString().Length ? AxesYMax.ToString() : AxesYMin.ToString();
                Rect.W = LabelPosition switch
                {
                    AxesLabelPosition.Axis => DistanceAxis.Value + maxString.CalcWidth(FontSize) + 10,
                    AxesLabelPosition.None => 1,
                    _ => throw new NotImplementedException(),
                };
            }
            else
            {
                //不可见时宽度为0
                Rect.W = 0;
            }
            Rect.H = AxisGroup.Rect.H;

            if (IsSecondaryAxis == false)
            {//主轴在左侧
                Rect.L = AxisGroup.Rect.X;
            }
            else
            {
                Rect.R = AxisGroup.Rect.W;
            }



            base.Drawing();
        }


        /// <summary>
        /// 获得最大值
        /// </summary>
        /// <param name="realValue"></param>
        /// <returns></returns>
        private double Carry(double realValue)
        {
            var negative = realValue < 0;//记录当前是否是复数

            var value = Math.Abs(realValue);
            var maxLength = ((int)value).ToString().Length;
            if (maxLength == 1)
            {
                value = Math.Ceiling(value);
            }
            else if (maxLength > 1)
            {
                var carry = Math.Pow(10, (maxLength - 2)) * 5;
                value = value + (carry - value % (carry));
            }

            if (negative) value *= -1;
            return value;

        }

        /// <summary>
        /// 轴的最大值
        /// </summary>
        public double AxesYMax { get; set; }

        /// <summary>
        /// 轴的最小值
        /// </summary>
        public double AxesYMin { get; set; }

        /// <summary>
        /// 根据值或者这个值在X轴的高度
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetHeightByValue(double value)
        {
            return (int)Math.Round((double)value / AxesYMax * Rect.H, 0);
        }
    }

}
