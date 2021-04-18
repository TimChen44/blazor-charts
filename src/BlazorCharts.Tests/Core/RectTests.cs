using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCharts.Tests.Core
{
    [TestClass()]
    public class RectTests
    {
        Rect r1 = new Rect(10, 20, 50, 100);
        Point p1 = new Point(20, 30);
        Size z1 = new Size(20, 30);
        Rect r2 = new Rect(new Point(30, 40), new Size(25, 50));

        [TestMethod()] public void GetX() => Assert.AreEqual(r1.X, 10);
        [TestMethod()]
        public void SetX()
        {
            var copy = r1.Copy();
            copy.X = 20;
            Assert.AreEqual(copy, new Rect(20, 20, 50, 100));
        }

        [TestMethod()] public void GetR() => Assert.AreEqual(r1.R, 60);
        [TestMethod()]
        public void SetT()
        {
            var copy = r1.Copy();
            copy.R = 200;
            Assert.AreEqual(copy, new Rect(150, 20, 50, 100));
        }

        [TestMethod()] public void T() => Assert.AreEqual(r1.Y, 20);
        [TestMethod()] public void B() => Assert.AreEqual(r1.B, 120);
        [TestMethod()] public void GetC() => Assert.AreEqual(r1.C, 35);
        [TestMethod()]
        public void SetC()
        {
            var copy = r1.Copy();
            copy.C = 200;
            Assert.AreEqual(copy, new Rect(175, 20, 50, 100));
        }

        [TestMethod()] public void M() => Assert.AreEqual(r1.M, 70);

        [TestMethod()] public void LT() => Assert.AreEqual(r1.LT, new Point(10, 20));
        [TestMethod()] public void LM() => Assert.AreEqual(r1.LM, new Point(10, 70));
        [TestMethod()] public void LB() => Assert.AreEqual(r1.LB, new Point(10, 120));

        [TestMethod()] public void CT() => Assert.AreEqual(r1.CT, new Point(35, 20));
        [TestMethod()] public void CM() => Assert.AreEqual(r1.CM, new Point(35, 70));
        [TestMethod()] public void CB() => Assert.AreEqual(r1.CB, new Point(35, 120));
        [TestMethod()] public void RT() => Assert.AreEqual(r1.RT, new Point(60, 20));
        [TestMethod()] public void RM() => Assert.AreEqual(r1.RM, new Point(60, 70));
        [TestMethod()] public void RB() => Assert.AreEqual(r1.RB, new Point(60, 120));

        [TestMethod()] public void AddPoint() => Assert.AreEqual(r1 + p1, new Rect(30, 50, 50, 100));
        [TestMethod()] public void SubPoint() => Assert.AreEqual(r1 - p1, new Rect(-10, -10, 50, 100));

        [TestMethod()] public void AddSize() => Assert.AreEqual(r1 + z1, new Rect(10, 20, 70, 130));
        [TestMethod()] public void SubSize() => Assert.AreEqual(r1 - z1, new Rect(10, 20, 30, 70));

    }
}
