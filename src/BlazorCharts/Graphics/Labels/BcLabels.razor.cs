using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BlazorCharts
{
    //标签配置
    public partial class BcLabels<TData> : ElementChart<TData>
    {
        /// <summary>
        /// 文本锚点
        /// </summary>
        [Display(Name = "文本锚点")]
        [Parameter] public TextAnchor TextAnchor { get; set; } = TextAnchor.Middle;

        //也可以用一个数组表示相对的百分比或者绝对像素值表示标签相对于图形包围盒左上角的位置。
        //position
        //top / left / right / bottom / inside / insideLeft / insideRight / insideTop / insideBottom / insideTopLeft / insideBottomLeft / insideTopRight / insideBottomRight


        //        distance  = 5 
        //number
        //距离图形元素的距离。
        //当 position 为字符描述值（如 'top'、'insideRight'）时候有效。

        //        color  = "#fff" 试一试
        //Color
        //文字的颜色。

        //如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。

        //        align  试一试
        //string
        //文字水平对齐方式，默认自动。

        //可选：

        //'left'
        //'center'
        //'right'
        //rich 中如果没有设置 align，则会取父层级的 align。例如：

        //        verticalAlign  试一试
        //string
        //文字垂直对齐方式，默认自动。

        //可选：

        //'top'
        //'middle'
        //'bottom'
        //rich 中如果没有设置 verticalAlign，则会取父层级的 verticalAlign。例如：

        //        backgroundColor  = 'transparent' 试一试
        //stringObject
        //文字块背景色。

        //可以使用颜色值，例如：'#123234', 'red', 'rgba(0,23,11,0.3)'。

        //        borderColor  试一试
        //Color
        //文字块边框颜色。

        //如果设置为 'inherit'，则为视觉映射得到的颜色，如系列色。

        //        borderWidth  试一试
        //number
        //文字块边框宽度。

        //        borderType  = 'solid' 试一试
        //stringnumberArray
        //文字块边框描边类型。

        //可选：

        //'solid'
        //'dashed'
        //'dotted'

//        padding  试一试
//numberArray
//文字块的内边距。例如：
    }
}
