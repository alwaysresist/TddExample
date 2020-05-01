using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
namespace LinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InitializationArray()
        {
            const int n = 5;
            double[] coeff = new double[n] { 1, 2, 3, 4, 5 };
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(2, a1[1]);
        }

        [TestMethod]
        public void InitializationList()
        {
            List<double> coeff = new List<double>() { 1, 2, 3, 4, 5, 6 };
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(4, a1[3]);
        }

        [TestMethod]
        public void InitializationString()
        {
            string coeff = "1,2,3,4,5,10.5,30.8";
            LinearEquation a1 = new LinearEquation(coeff);
            Assert.AreEqual(10.5, a1[5]);
        }

        [TestMethod]
        public void InitializationZero()
        {
            int n = 5;
            LinearEquation a = new LinearEquation(n);
            Assert.AreEqual("0x1+0x2+0x3+0x4+0x5=0", a.ToString());
        }

        [TestMethod]
        public void CorrectSum()
        {
            string coeff1 = "1,2,3,4,5,10.5,30.8";
            LinearEquation a1 = new LinearEquation(coeff1);
            string coeff2 = "-1,-2,-3,-4,-5,-10.5,-30.8";
            LinearEquation a2 = new LinearEquation(coeff2);
            string res = "0,0,0,0,0,0";
            Assert.AreEqual(new LinearEquation(res), a1 + a2);
        }

        [TestMethod]
        public void CorrectSub()
        {
            string coeff1 = "1,2,3,4,5";
            LinearEquation a1 = new LinearEquation(coeff1);
            string coeff2 = "2,4,6,9,10";
            LinearEquation a2 = new LinearEquation(coeff2);
            string res = "-1,-2,-3,-5,-5";
            Assert.AreEqual(new LinearEquation(res), a1 - a2);
        }

        [TestMethod]
        public void CorrectUnaryMinus()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            string res = "-1,-2,-3,-4,-5";
            Assert.AreEqual(new LinearEquation(res), -a);
        }

        [TestMethod]
        public void CorrectMult1()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            string res = "2,4,6,8,10";
            Assert.AreEqual(new LinearEquation(res), a * 2);
        }

        [TestMethod]
        public void CorrectMult2()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            string res = "2,4,6,8,10";
            Assert.AreEqual(new LinearEquation(res), 2 * a);
        }

        [TestMethod]
        public void CorrectIndexing()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            Assert.AreEqual(4, a[3]);
        }

        [TestMethod]
        public void CorrectSameInitialization()
        {
            LinearEquation a = new LinearEquation(4);
            a.SameInitialization(10);
            string res = "10,10,10,10,10";
            Assert.AreEqual(new LinearEquation(res), a);
        }

        [TestMethod]
        public void ContradictoryEquation()
        {
            string res = "0,0,0,10";
            LinearEquation a = new LinearEquation(res);
            bool check = (a) ? true: false;
            Assert.AreEqual(false, check);
        }

        [TestMethod]
        public void SolvableEquation()
        {
            string res = "2,1,3,10";
            LinearEquation a = new LinearEquation(res);
            bool check = (a) ? true : false;
            Assert.AreEqual(true, check);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailIndex1()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            Assert.Equals(typeof(IndexOutOfRangeException), a[10]);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailIndex2()
        {
            string coeff = "1,2,3,4,5";
            LinearEquation a = new LinearEquation(coeff);
            Assert.Equals(typeof(IndexOutOfRangeException), a[-2]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FailArgument()
        {
            Assert.Equals(typeof(ArgumentException), new LinearEquation(-133));
        }
    }
}
