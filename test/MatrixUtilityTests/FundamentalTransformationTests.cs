using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatrixUtility.Tests
{
    [TestClass()]
    public class FundamentalTransformationTests
    {
        static bool EqualsList<T>(IReadOnlyList<IReadOnlyList<T>> xss, IReadOnlyList<IReadOnlyList<T>> yss) {
            return xss.Zip(yss, (xs, ys) =>
                xs.Zip(ys, (x, y) => x.Equals(y)).All(x => x))
                .All(x => x);
        }

        [TestMethod()]
        public void SwapRowTest() {
            /* Arrange */
            List<List<int>> target = new List<List<int>>() {
                new List<int>() { 1, 2, 3 },
                new List<int>() { 4, 5, 7 },
                new List<int>() { 8, 9, 10 },
            };

            /* Act */
            FundamentalTransformation<int>.SwapRow(target, 0, 1);

            IReadOnlyList<IReadOnlyList<int>> expect = new List<List<int>>() {
                new List<int>() { 4, 5, 7 },
                new List<int>() { 1, 2, 3 },
                new List<int>() { 8, 9, 10 },
            };
            /* Assert: targetとexpectが、同じ値のリストであることを確認する */
            Assert.IsTrue(EqualsList(target, expect));
        }

        [TestMethod()]
        public void SwapColumnTest() {
            /* Arrange */
            List<List<int>> target = new List<List<int>>() {
                new List<int> { 1, 2, 3 },
                new List<int> { 4, 5, 6 },
                new List<int> { 7, 8, 9 },
            };

            /* Act */
            FundamentalTransformation<int>.SwapColumn(target, 1, 2);

            IReadOnlyList<IReadOnlyList<int>> expect = new List<List<int>>() {
                new List<int> { 1, 3, 2 },
                new List<int> { 4, 6, 5 },
                new List<int> { 7, 9, 8 },
            };
            /* Assert */
            Assert.IsTrue(EqualsList(target, expect));
        }
    }
}