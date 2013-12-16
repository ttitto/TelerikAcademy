using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CountRepetitionsInArray;

namespace CountRepetitionsInArrayTest
{
    [TestClass]
    public class CountRepetitionsInArrayTestClass
    {
        [TestMethod]
        public void CountRepetitionsInArrayTest1()
        {
            double[] testArr1 = {12,55,46,58.05,58,12.0,49,57,12};
            Assert.AreEqual(CountRepetitionsInArrayClass.CountRepetitionsOf(testArr1, 12), 3);
            Assert.AreEqual(CountRepetitionsInArrayClass.CountRepetitionsOf(testArr1, 58), 1);
        }
    }
}
