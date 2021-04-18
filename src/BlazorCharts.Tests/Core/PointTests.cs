using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlazorCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts.Tests
{
    [TestClass()]
    public class PointTests
    {
        Point p1 = new Point(50, 100);
        Point p2 = new Point(25, 50);

        [TestMethod()]
        public void PointTest1() => Assert.AreEqual(new Point(50, 100), p1);
        [TestMethod()]
        public void PointTest2() => Assert.AreEqual(true, p1 != p2);
        [TestMethod()]
        public void PointTest3() => Assert.AreEqual(new Point(75, 150), p1 + p2);
        [TestMethod()]
        public void PointTest4() => Assert.AreEqual(new Point(25, 50), p1 - p2);

    }
}