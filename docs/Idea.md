# 图表结构

- 标题 Title
- 图例 Legend
- 坐标轴 AxisGroup
    - X轴 AxesX
        - 刻度 Scale
        - 值 Value
        - 标题 Title
    - Y轴 AxesY
        - 左轴
        - 右轴
    - 网格 Grid
        - 横线 LineH
        - 竖线 LineV
- 系列组 SeriesGroup
    - 系列 Series
- 标签 Labels
- 提示 Tooltip
- 背景 Background

# 生命周期

初始化(init) -> 跟新布局 -> 更新数据 -> 销毁

# 元素位置和尺寸确定顺序

1. 图表
1. 标题
1. 图例
1. 主区域
1. 坐标轴
    - X轴高 -> Y轴宽 -> X轴宽 -> Y轴高
1. 网格
1. 系列组

# 显示方式

SVG

