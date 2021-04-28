# blazor-charts
基于blazor技术，使用C#编写的charts组件。

# Demo

[https://victorious-meadow-0c2078000.azurestaticapps.net/](https://victorious-meadow-0c2078000.azurestaticapps.net/)

### 当前效果

![image](https://user-images.githubusercontent.com/7581981/116263448-f5cc8680-a7ab-11eb-94d3-3ec488a2f47b.png)


### 使用方法
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
string title = "不在意现在有多糟糕，看好将来有多精彩。";

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
