# blazor-charts

![无标题](https://user-images.githubusercontent.com/7581981/116421071-1b6f9380-a871-11eb-88a6-9abb8e1b165f.png)

基于blazor技术，使用C#编写的web前端charts组件。

DemoSite: [https://victorious-meadow-0c2078000.azurestaticapps.net/](https://victorious-meadow-0c2078000.azurestaticapps.net/)

| Build | NuGet |
|--|--|
|![](https://github.com/TimChen44/blazor-charts/workflows/.NET/badge.svg)|[![](https://img.shields.io/nuget/v/BlazorCharts.svg)](https://www.nuget.org/packages/BlazorCharts)|

### 特点

✨ 完全使用C#语言编写

✨ 使用Razor语法定义图表

✨ 图表组件灵活组合使用

### 使用方法

1. 安装组件包

2. 修改`_Imports.razor`文件，添加引用`@using BlazorCharts`

3. 页面中使用

```html
<BcChart Height="400" Width="600" Data="githubs" CategoryField="x=>x.Year.ToString()">
    <BcTitle Title="@title" TData="Github"></BcTitle>
    <BcBarSeries TData="Github" ValueFunc="x=>x.Sum(y=>y.View)" Group="View"></BcBarSeries>
    <BcBarSeries TData="Github" ValueFunc="x=>x.Sum(y=>y.Start)" Group="Start"></BcBarSeries>
    <BcLineSeries TData="Github" ValueFunc="x=>x.Sum(y=>y.Fork)" Group="Fork"></BcLineSeries>
    <BcLegend TData="Github" BorderWidth="1" Position="@LegendPosition.Bottom"></BcLegend>
</BcChart>
```

```csharp
string title = "图表示例";

List<Github> githubs = new List<Github>()
{
    new Github(){Year=2017,View =2500,Start=800,Fork=400},
    new Github(){Year=2018,View =2200,Start=900,Fork=800},
    new Github(){Year=2019,View =2800,Start=1100,Fork=700},
    new Github(){Year=2020,View =2600,Start=1400,Fork=900},
};


public class Github
{
    public int Year { get; set; }
    public int View { get; set; }
    public int Start { get; set; }
    public int Fork { get; set; }
}
```

4. 执行查看效果

![image](https://user-images.githubusercontent.com/7581981/116768715-5b01cf80-aa6b-11eb-940f-c0a2145f9a3d.png)

### 更新日志

**2021.0525**
- 增加自定义数据源功能，默认提供ListDataSource和RemoteDataSource两种类型的数据源

**2021.0520**
- X轴和Y轴增加隐藏功能
- Y轴增加次要轴功能

**2021.0514**
- 支持某个字段作为分组依据进行分组
- 增加基本的数据筛选支持

**2021.0509**
- 柱状图和点的图增加动画

**2021.0501**
- 文档增加更新日志
- Title组件增加文本位置属性
- Y轴增加主要和次要的单位和网格线
- X轴增加网格线
- 优化Y轴刻度计算算法
- 坐标轴增加标签位置和文字偏移

