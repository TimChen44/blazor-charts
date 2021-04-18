using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts
{
    public class Rect
    {
        public Rect()
        {
            Point = new Point();
            Size = new Size();
        }

        public Rect(int x, int y, int w, int h)
        {
            Point = new Point(x, y);
            Size = new Size(w, h);
        }

        public Rect(Point point, Size size)
        {
            Point = point;
            Size = size;
        }

        /// <summary>
        /// 坐标点
        /// </summary>
        public Point Point { get; set; }

        /// <summary>
        /// 尺寸
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// 复制尺寸
        /// </summary>
        /// <returns></returns>
        public Rect Copy()
        {
            return new Rect(Point.X, Point.Y, Size.W, Size.H);
        }

        /// <summary>
        /// 获取或设置左边线
        /// 设置后右边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int X
        {
            get { return Point.X; }
            set { Point.X = value; }
        }

        /// <summary>
        /// 获取或设置顶边线
        /// 设置后底边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int Y
        {
            get { return Point.Y; }
            set { Point.Y = value; }
        }

        /// <summary>
        /// 获取或设置宽度
        /// </summary>
        public int W
        {
            get { return Size.W; }
            set { Size.W = value; }
        }

        /// <summary>
        /// 获取或设置高度
        /// </summary>
        public int H
        {
            get { return Size.H; }
            set { Size.H = value; }
        }

        #region 边线坐标点

        /// <summary>
        /// 获取或设置右边线
        /// 设置后左边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int R
        {
            get { return Point.X + Size.W; }
            set { Point.X = value - Size.W; }
        }


        /// <summary>
        /// 获取或设置底边线
        /// 设置后顶边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int B
        {
            get { return Point.Y + Size.H; }
            set { Point.Y = value - Size.H; }
        }

        /// <summary>
        /// 获取或设置左右中心
        /// 设置后左右边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int C
        {
            get { return Point.X + Size.W / 2; }
            set { Point.X = value- Size.W / 2; }
        }


        /// <summary>
        /// 获取或设置上下中心
        /// 设置后上下边线线会随之移动，优先保证尺寸不变
        /// </summary>
        public int M
        {
            get { return Point.Y + Size.H / 2; }
            set { Point.Y =  value- Size.H / 2; }
        }

        #endregion

        #region 四周坐标点
        //TODO:之后根据需要决定属性是否可以赋值

        /// <summary>
        /// 左上
        /// </summary>
        /// <returns></returns>
        public Point LT => new Point(Point.X, Point.Y);
        /// <summary>
        /// 左中
        /// </summary>
        /// <returns></returns>
        public Point LM => new Point(Point.X, Point.Y + Size.H / 2);
        /// <summary>
        /// 左下
        /// </summary>
        /// <returns></returns>
        public Point LB => new Point(Point.X, Point.Y + Size.H);

        /// <summary>
        /// 中上
        /// </summary>
        /// <returns></returns>
        public Point CT => new Point(Point.X + Size.W / 2, Point.Y);
        /// <summary>
        /// 中中
        /// </summary>
        /// <returns></returns>
        public Point CM => new Point(Point.X + Size.W / 2, Point.Y + Size.H / 2);
        /// <summary>
        /// 中下
        /// </summary>
        /// <returns></returns>
        public Point CB => new Point(Point.X + Size.W / 2, Point.Y + Size.H);

        /// <summary>
        /// 右上
        /// </summary>
        /// <returns></returns>
        public Point RT => new Point(Point.X + Size.W, Point.Y);
        /// <summary>
        /// 右中
        /// </summary>
        /// <returns></returns>
        public Point RM => new Point(Point.X + Size.W, Point.Y + Size.H / 2);
        /// <summary>
        /// 右下
        /// </summary>
        /// <returns></returns>
        public Point RB => new Point(Point.X + Size.W, Point.Y + Size.H);

        #endregion 

        #region 操作符重载

        /// <summary>
        /// 正向偏移坐标
        /// </summary>
        public static Rect operator +(Rect rect, Point point)
        {
            return new Rect(rect.Point + point, rect.Size);
        }

        /// <summary>
        /// 反向偏移坐标
        /// </summary>
        public static Rect operator -(Rect rect, Point point)
        {
            return new Rect(rect.Point - point, rect.Size);
        }

        /// <summary>
        /// 增加尺寸
        /// </summary>
        public static Rect operator +(Rect rect, Size size)
        {
            return new Rect(rect.Point, rect.Size + size);
        }

        /// <summary>
        /// 减少尺寸
        /// </summary>
        public static Rect operator -(Rect rect, Size size)
        {
            return new Rect(rect.Point, rect.Size - size);
        }

        /// <summary>
        /// 相等判断
        /// </summary>
        public static bool operator ==(Rect r1, Rect r2)
        {
            return r1.Point == r2.Point && r1.Size == r2.Size;
        }

        public static bool operator !=(Rect r1, Rect r2)
        {
            return !(r1.Point == r2.Point && r1.Size == r2.Size);
        }

        public override bool Equals(object obj)
        {
            if (obj is Rect rect)
                return this == rect;
            else
                return false;
        }

        #endregion 
    }

    public class Point
    {
        public Point()
        {

        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// X轴坐标
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Y轴坐标
        /// </summary>
        public int Y { get; set; }

        #region 操作符重载

        /// <summary>
        /// 坐标相加
        /// </summary>
        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.X + p2.X, p1.Y + p2.Y);
        }

        /// <summary>
        /// 坐标相减
        /// </summary>
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }

        /// <summary>
        /// 相等判断
        /// </summary>
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1.X == p2.X && p1.Y == p2.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Point point)
                return this == point;
            else
                return false;
        }

        #endregion 
    }

    public class Size
    {
        public Size()
        {

        }

        public Size(int w, int h)
        {
            W = w;
            H = h;
        }

        /// <summary>
        /// 宽度
        /// </summary>
        public int W { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public int H { get; set; }


        #region 操作符重载

        /// <summary>
        /// 坐标相加
        /// </summary>
        public static Size operator +(Size z1, Size z2)
        {
            return new Size(z1.W + z2.W, z1.H + z2.H);
        }

        /// <summary>
        /// 坐标相减
        /// </summary>
        public static Size operator -(Size z1, Size z2)
        {
            return new Size(z1.W - z2.W, z1.H - z2.H);
        }

        /// <summary>
        /// 相等判断
        /// </summary>
        public static bool operator ==(Size z1, Size z2)
        {
            return z1.W == z2.W && z1.H == z2.H;
        }

        public static bool operator !=(Size z1, Size z2)
        {
            return !(z1.W == z2.W && z1.H == z2.H);
        }

        public override bool Equals(object obj)
        {
            if (obj is Size size)
                return this == size;
            else
                return false;
        }

        #endregion 

    }
}
