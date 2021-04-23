# blazor-charts
基于blazor技术，使用C#编写的charts组件。


### 当前效果

![alt tag](https://github.com/TimChen44/blazor-charts/blob/main/docs/img/demo1.png)

### 使用方法
```html
<BcChart Height="400" Width="600" Data="githubs" CategoryField="x=>x.Year.ToString()">
    <BcTitle Title="@title" TData="Github"></BcTitle>
    <BcBarSeries TData="Github" ValueFunc="x=>x.Sum(y=>y.Start)" Group="Start"></BcBarSeries>
    <BcLineSeries TData="Github" ValueFunc="x=>x.Sum(y=>y.Fork)" Group="Fork"></BcLineSeries>
</BcChart>
```

```csharp
string title = "不在意现在有多糟糕，看好将来有多精彩。";

List<Github> githubs = new List<Github>()
{
    new Github(){Year=2017,Start=800,Fork=400},
    new Github(){Year=2018,Start=900,Fork=800},
    new Github(){Year=2019,Start=1100,Fork=700},
    new Github(){Year=2020,Start=1400,Fork=900},
};


public class Github
{
    public int Year { get; set; }
    public int Start { get; set; }
    public int Fork { get; set; }
}
```