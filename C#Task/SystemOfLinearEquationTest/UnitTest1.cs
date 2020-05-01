using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task2;
namespace SystemOfLinearEquationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CorrectIndexing()
        {
            int n = 3;
            SysOfLinearEquation s = new SysOfLinearEquation(n);
            s.Add(new LinearEquation("1, 2, 3, 15"));
            s.Add(new LinearEquation("2, 4, 3, 20"));
            s.Add(new LinearEquation("5, 6, 7, 33"));
            Assert.AreEqual(new LinearEquation("2, 4, 3, 20"), s[1]);
        }
        [TestMethod]
        public void CorrectAnswer()
        {
            int n = 3;
            SysOfLinearEquation s = new SysOfLinearEquation(n);
            s.Add(new LinearEquation("3, 2, -4, 3"));
            s.Add(new LinearEquation("2, 3, 3, 15"));
            s.Add(new LinearEquation("5, -3, 1, 14"));
            s.StepUp();
            double[] solve1 = new double[] { 3, 1, 2 };
            double[] solve2 = s.Solve();
            bool check = true;
            for (int i = 0; i < n; i++)
            {
                if (Math.Abs(solve1[i] - solve2[i]) > 1e-9) check = false;
            }
            Assert.AreEqual(true,check);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing1()
        {
            int n = 3;
            SysOfLinearEquation s = new SysOfLinearEquation(n);
            s.Add(new LinearEquation("1, 2, 3, 15"));
            s.Add(new LinearEquation("2, 4, 3, 20"));
            s.Add(new LinearEquation("5, 6, 7, 33"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[-1]);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void FailWithIndexing2()
        {
            int n = 3;
            SysOfLinearEquation s = new SysOfLinearEquation(n);
            s.Add(new LinearEquation("1, 2, 3, 10"));
            s.Add(new LinearEquation("4, 5, 6, 20"));
            s.Add(new LinearEquation("7, 8, 9, 30"));
            Assert.Equals(typeof(IndexOutOfRangeException), s[12]);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckNoSolutions()
        {
            int n = 3;
            SysOfLinearEquation s = new SysOfLinearEquation(n);
            s.Add(new LinearEquation("3, 2,-4, 3"));
            s.Add(new LinearEquation("6, 4 -8, 15"));
            s.Add(new LinearEquation("6, 4, -8, 15"));
            s.StepUp();
            Assert.Equals(typeof(ArgumentException), s.Solve());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void InfinitelyManySolutions()
        {
            int n = 3;
            SysOfLinearEquation s = new SysOfLinearEquation(n);
            s.Add(new LinearEquation("3, 2,-4, 7"));
            s.Add(new LinearEquation("6, 4, -8, 15"));
            s.Add(new LinearEquation("6, 4, -8, 15"));
            s.StepUp();
            Assert.Equals(typeof(ArgumentException), s.Solve());
        }
    }
}
