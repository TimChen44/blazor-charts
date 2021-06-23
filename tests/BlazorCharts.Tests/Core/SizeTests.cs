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
    public class SizeTests
    {
        Size z1 = new Size(50, 100);
        Size z2 = new Size(25, 50);

        [TestMethod()]
        public void SizeTest1() => Assert.AreEqual(new Size(50, 100), z1);

        [TestMethod()]
        public void SizeTest2() => Assert.AreEqual(true, z1 != z2);

        [TestMethod()]
        public void SizeTest3() => Assert.AreEqual(new Size(75, 150), z1 + z2);

        [TestMethod()]
        public void SizeTest4() => Assert.AreEqual(new Size(25, 50), z1 - z2);

    }
}