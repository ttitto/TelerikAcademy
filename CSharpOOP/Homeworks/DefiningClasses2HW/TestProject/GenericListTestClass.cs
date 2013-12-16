using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;
using Matrices;
namespace TestProject
{
    [TestClass]
    public class GenericListTestClass
    {
        GenericList<double> myDoubleList = new GenericList<double>(4);

        [TestMethod]
        public void TestAdd()
        {
            myDoubleList.Add(1.2);
            myDoubleList.Add(4.3);
            myDoubleList.Add(3.5);
            myDoubleList.Add(-25);
            myDoubleList.Add(-165.25);
            myDoubleList.Add(0);
            myDoubleList.Add(3.5);
            string actual = myDoubleList.ToString();
            string expected = @"1.2, 4.3, 3.5, -25, -165.25, 0, 3.5";
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestRemoveAt()
        {
            myDoubleList.Add(1.2);
            myDoubleList.Add(4.3);
            myDoubleList.Add(3.5);
            myDoubleList.Add(-25);
            myDoubleList.Add(-165.25);
            myDoubleList.Add(0);
            myDoubleList.Add(3.5);

            myDoubleList.RemoveAt(new[] { 2, 3, 5 });
            string actual = myDoubleList.ToString();
            string expected = @"1.2, 4.3, -165.25, 3.5";
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestFind()
        {
            myDoubleList.Add(1.2);
            myDoubleList.Add(4.3);
            myDoubleList.Add(3.5);
            myDoubleList.Add(-25);
            myDoubleList.Add(-165.25);
            myDoubleList.Add(0);
            myDoubleList.Add(3.5);
            int actual = myDoubleList.Find(3.5, 3, 10);
            int expected = 6;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestClear()
        {
            myDoubleList.Add(1.2);
            myDoubleList.Add(4.3);
            myDoubleList.Add(3.5);
            myDoubleList.Add(-25);
            myDoubleList.Add(-165.25);
            myDoubleList.Add(0);
            myDoubleList.Add(3.5);
            myDoubleList.Clear(3);
            string actual = myDoubleList.ToString();
            string expected = "";
            Assert.AreEqual(actual, expected);
            int capacityActual = myDoubleList.Capacity;
            int capacityExpected = 3;
            Assert.AreEqual(capacityActual, capacityExpected);
        }
        [TestMethod]
        public void TestInsertAt()
        {
            myDoubleList.Add(1.2);
            myDoubleList.Add(4.3);
            myDoubleList.Add(3.5);
            myDoubleList.Add(-25);
            myDoubleList.Add(-165.25);
            myDoubleList.Add(0);
            myDoubleList.Add(3.5);
            myDoubleList.InsertAt(4.8, 6);
            string actual = myDoubleList.ToString();
            string expected = @"1.2, 4.3, 3.5, -25, -165.25, 0, 4.8, 3.5";
            Assert.AreEqual(actual, expected);
        }
    }
    [TestClass]
    public class MatrixTestClass
    {
        Matrix<double> myMatrix1 = new Matrix<double>(5, 3);
        Matrix<double> myMatrix2 = new Matrix<double>(3, 6);

        [TestMethod]
        public void TestToString()
        {
            #region Matrix1
            myMatrix1[0, 0] = -1;
            myMatrix1[0, 1] = 2;
            myMatrix1[0, 2] = 3;
            myMatrix1[1, 0] = 4.687;
            myMatrix1[1, 1] = 5;
            myMatrix1[1, 2] = 6;
            myMatrix1[2, 0] = -7.5;
            myMatrix1[2, 1] = 8;
            myMatrix1[2, 2] = 9;
            myMatrix1[3, 0] = 10;
            myMatrix1[3, 1] = 11;
            myMatrix1[3, 2] = 12;
            myMatrix1[4, 0] = -13.544;
            myMatrix1[4, 1] = 14;
            myMatrix1[4, 2] = -15.45;
            #endregion

            #region Matrix2
            myMatrix2[0, 0] = 16;
            myMatrix2[0, 1] = 17;
            myMatrix2[0, 2] = 18;
            myMatrix2[0, 3] = -19.5;
            myMatrix2[0, 4] = 20;
            myMatrix2[0, 5] = 21;
            myMatrix2[1, 0] = -22.05;
            myMatrix2[1, 1] = 23;
            myMatrix2[1, 2] = 24;
            myMatrix2[1, 3] = 25;
            myMatrix2[1, 4] = 26;
            myMatrix2[1, 5] = 27.65;
            myMatrix2[2, 0] = 28;
            myMatrix2[2, 1] = 29;
            myMatrix2[2, 2] = 30.85;
            myMatrix2[2, 3] = 31;
            myMatrix2[2, 4] = 32;
            myMatrix2[2, 5] = 33.1;
            #endregion

            string actual = myMatrix1.ToString();
            string expected = "-1,2,3\n4.687,5,6\n-7.5,8,9\n10,11,12\n-13.544,14,-15.45";
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestMultiplication()
        {
            #region Matrix1
            myMatrix1[0, 0] = -1;
            myMatrix1[0, 1] = 2;
            myMatrix1[0, 2] = 3;
            myMatrix1[1, 0] = 4.687;
            myMatrix1[1, 1] = 5;
            myMatrix1[1, 2] = 6;
            myMatrix1[2, 0] = -7.5;
            myMatrix1[2, 1] = 8;
            myMatrix1[2, 2] = 9;
            myMatrix1[3, 0] = 10;
            myMatrix1[3, 1] = 11;
            myMatrix1[3, 2] = 12;
            myMatrix1[4, 0] = -13.544;
            myMatrix1[4, 1] = 14;
            myMatrix1[4, 2] = -15.45;
            #endregion
            #region Matrix2
            myMatrix2[0, 0] = 16;
            myMatrix2[0, 1] = 17;
            myMatrix2[0, 2] = 18;
            myMatrix2[0, 3] = -19.5;
            myMatrix2[0, 4] = 20;
            myMatrix2[0, 5] = 21;
            myMatrix2[1, 0] = -22.05;
            myMatrix2[1, 1] = 23;
            myMatrix2[1, 2] = 24;
            myMatrix2[1, 3] = 25;
            myMatrix2[1, 4] = 26;
            myMatrix2[1, 5] = 27.65;
            myMatrix2[2, 0] = 28;
            myMatrix2[2, 1] = 29;
            myMatrix2[2, 2] = 30.85;
            myMatrix2[2, 3] = 31;
            myMatrix2[2, 4] = 32;
            myMatrix2[2, 5] = 33.1;
            #endregion

            Matrix<double> result = myMatrix1 * myMatrix2;
            string actual = result.ToString();
            string expected = "23.9,116,122.55,162.5,128,133.6\n132.742,368.679,389.466,219.6035,415.74,435.277\n-44.4,317.5,334.65,625.25,346,361.6\n253.45,771,814.2,452,870,911.35\n-958.004,-356.298,-384.4245,135.158,-401.28,-408.719";

            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void TestTrue()
        {
            #region Matrix1
            myMatrix1[0, 0] = -1;
            myMatrix1[0, 1] = 2;
            myMatrix1[0, 2] = 3;
            myMatrix1[1, 0] = 4.687;
            myMatrix1[1, 1] = 5;
            myMatrix1[1, 2] = 6;
            myMatrix1[2, 0] = -7.5;
            myMatrix1[2, 1] = 8;
            myMatrix1[2, 2] = 9;
            myMatrix1[3, 0] = 10;
            myMatrix1[3, 1] = 11;
            myMatrix1[3, 2] = 12;
            myMatrix1[4, 0] = -13.544;
            myMatrix1[4, 1] = 14;
            myMatrix1[4, 2] = -15.45;
            #endregion
            #region Matrix2
            myMatrix2[0, 0] = 16;
            myMatrix2[0, 1] = 17;
            myMatrix2[0, 2] = 18;
            myMatrix2[0, 3] = -19.5;
            myMatrix2[0, 4] = 20;
            myMatrix2[0, 5] = 21;
            myMatrix2[1, 0] = -22.05;
            myMatrix2[1, 1] = 0;
            myMatrix2[1, 2] = 24;
            myMatrix2[1, 3] = 25;
            myMatrix2[1, 4] = 26;
            myMatrix2[1, 5] = 27.65;
            myMatrix2[2, 0] = 28;
            myMatrix2[2, 1] = 29;
            myMatrix2[2, 2] = 30.85;
            myMatrix2[2, 3] = 31;
            myMatrix2[2, 4] = 32;
            myMatrix2[2, 5] = 33.1;
            #endregion
            bool ContainsZero = false;
            if (myMatrix1) ContainsZero = true;
            Assert.IsFalse(ContainsZero);
        }
        [TestMethod]
        public void TestFalse()
        {
            #region Matrix2
            myMatrix2[0, 0] = 16;
            myMatrix2[0, 1] = 17;
            myMatrix2[0, 2] = 18;
            myMatrix2[0, 3] = -19.5;
            myMatrix2[0, 4] = 20;
            myMatrix2[0, 5] = 21;
            myMatrix2[1, 0] = -22.05;
            myMatrix2[1, 1] = 0;
            myMatrix2[1, 2] = 24;
            myMatrix2[1, 3] = 25;
            myMatrix2[1, 4] = 26;
            myMatrix2[1, 5] = 27.65;
            myMatrix2[2, 0] = 28;
            myMatrix2[2, 1] = 29;
            myMatrix2[2, 2] = 30.85;
            myMatrix2[2, 3] = 31;
            myMatrix2[2, 4] = 32;
            myMatrix2[2, 5] = 33.1;
            #endregion

            bool ContainsZero = true;
            if (myMatrix2) ContainsZero = false;
            Assert.IsTrue(ContainsZero);
        }
    }
}
