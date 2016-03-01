using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrigonalSolver;
using static MatrixUtility.Functions;

namespace TrigonalSolver.Tests
{
    [TestClass()]
    public class GaussianEliminationTests
    {
        [TestMethod()]
        public void SolveTest() {
            /**
             * Arrange
             */
            var A = new List<List<double>>() {
                new List<double>() { 1.5, 2.5, 0 },
                new List<double>() { 4.5, 5.5, 6.5 },
                new List<double>() { 0,   8.5, 9.5 },
            };
            var b = new List<double>() {
                10.0,
                11.0,
                12.0,
            };
            double det = GetDeterminant3(A);

            /**
             * Act
             */
            var A2 = new List<List<double>> {
                A[0].ToList(),
                A[1].ToList(),
                A[2].ToList(),
            };
            var b2 = b.ToList(); /* copy */
            GaussianElimination.Solve(A2, b2);

            /**
             * Assert
             */
            /* Cramer's rule */
            double x0 = GetDeterminant3(new List<List<double>> {
                new List<double> { b[0], A[0][1], A[0][2] },
                new List<double> { b[1], A[1][1], A[1][2] },
                new List<double> { b[2], A[2][1], A[2][2] },
            }) / det;
            double x1 = GetDeterminant3(new List<List<double>> {
                new List<double> { A[0][0], b[0], A[0][2] },
                new List<double> { A[1][0], b[1], A[1][2] },
                new List<double> { A[2][0], b[2], A[2][2] },
            }) / det;
            double x2 = GetDeterminant3(new List<List<double>> {
                new List<double> { A[0][0], A[0][1], b[0] },
                new List<double> { A[1][0], A[1][1], b[1] },
                new List<double> { A[2][0], A[2][1], b[2] },
            }) / det;

            /* 小数第3位での比較 */
            var coeff = Math.Pow(10, 2);
            Assert.AreEqual(true, coeff * Math.Abs(x0 - b2[0]) < 1);
            Assert.AreEqual(true, coeff * Math.Abs(x1 - b2[1]) < 1);
            Assert.AreEqual(true, coeff * Math.Abs(x2 - b2[2]) < 1);
        }
    }
}
