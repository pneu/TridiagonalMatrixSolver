using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static MatrixUtility.Functions;

namespace MatrixUtility.Tests
{
    [TestClass()]
    public class MatrixUtilityTests
    {
        [TestMethod()]
        public void GetDeterminantTest() {
            var A = new List<List<double>>() {
                new List<double>() { 1, -2, 5 },
                new List<double>() { 3, 1, 4 },
                new List<double>() { -3, 0, 2},
            };
            var det = GetDeterminant3(A);
            Assert.AreEqual(53, det);
        }
    }
}