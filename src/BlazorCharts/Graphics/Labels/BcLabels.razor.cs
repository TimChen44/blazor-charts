using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    /// <summary>
    /// 标签配置
    /// 每一个标签会有一个默认的矩形区域，此区域的大小默认由系列Series给定
    /// 通过一些参数控制文本的位置，矩形的颜色等
    /// 此类时标签的管理，通过属性由Series给与需要显示标签的位置
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public partial class BcLabels<TData> : ElementChart<TData>
    {
        /// <summary>
        /// 文本锚点
        /// </summary>
        [Display(Name = "文本锚点")]
        [Parameter] public TextAnchor TextAnchor { get; set; } = TextAnchor.Middle;

        /// <summary>
        /// 用一个数组表示相对的百分比或者绝对像素值表示标签相对于图形包围盒左上角的位置。
        /// </summary>
        [Parameter] public LabelsPosition Position { get; set; }

        /// <summary>
        /// 距离中心位置，当Position不为Center时生效
        /// </summary>
        [Parameter] public int Distance { get; set; }

        /// <summary>
        /// 标签字体颜色
        /// </summary>
        [Parameter] public string Color { get; set; } = "#fff";
        //继承inherit模式暂时没想好如何实现比较好

        /// <summary>
        /// 文本对齐
        /// </summary>
        [Parameter] public TextAlign Align { get; set; } = TextAlign.Center;

        /// <summary>
        /// 文本垂直对齐
        /// </summary>
        [Parameter] public TextVerticalAlign VerticalAlign { get; set; }


        /// <summary>
        /// 文字块背景颜色
        /// </summary>
        [Parameter] public string BackgroundColor { get; set; } = "transparent";


        /// <summary>
        /// 文字块边框颜色
        /// </summary>
        [Parameter] public string BorderColor { get; set; } = "transparent";

        /// <summary>
        /// 文本块边框宽度
        /// </summary>
        [Parameter] public int BorderWidth { get; set; }

        /// <summary>
        /// 边框类型
        /// </summary>
        [Parameter] public BorderType BorderType { get; set; }

        /// <summary>
        /// 格式化显示内容
        /// </summary>
        [Display(Name = "格式化")]
        [Parameter] public Func<double, string> Formate { get; set; }


        public List<Point> Points { get; set; }
    }

    public record LabelPoint
    {
        public double Value { get; set; }

        public Point Point { get; set; }
    }


    /// <summary>
    /// 标签相对于标签区域的位置
    /// </summary>
    public enum LabelsPosition
    {
        [Description("center")]
        Center,
        [Description("top")]
        Top,
        [Description("left")]
        Left,
        [Description("right")]
        Right,
        [Description("bottom")]
        Bottom,
        //inside / insideLeft / insideRight / insideTop / insideBottom / insideTopLeft / insideBottomLeft / insideTopRight / insideBottomRight
    }

    /// <summary>
    /// 文本垂直对齐
    /// </summary>
    public enum TextVerticalAlign
    {
        [Description("top")]
        Top,
        [Description("middle")]
        Middle,
        [Description("bottom")]
        Bottom,
    }

    public enum BorderType
    {
        [Description("solid")]
        Solid,
        [Description("dashed")]
        Dashed,
        [Description("dotted")]
        Dotted,

    }
}
