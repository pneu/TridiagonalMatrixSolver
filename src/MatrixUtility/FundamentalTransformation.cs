using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixUtility
{
    public static class FundamentalTransformation<T>
    {
        /// <summary>
        /// 行交換
        /// </summary>
        /// <param name="i">交換する1つ目の行</param>
        /// <param name="j">交換する2つ目の行</param>
        public static void SwapRow(List<List<T>> matrix, int i, int j) {
            var tmp = new List<T>(matrix[i]);
            matrix[i] = matrix[j];
            matrix[j] = tmp;
        }

        /// <summary>
        /// 列交換
        /// </summary>
        /// <param name="i">交換する1つ目の列</param>
        /// <param name="j">交換する2つ目の列</param>
        public static void SwapColumn(List<List<T>> matrix, int i, int j) {
            for (int n = 0; n < matrix.Count; n++) {
                var t = SwapValue(matrix[n][i], matrix[n][j]);
                matrix[n][i] = t.Item1;
                matrix[n][j] = t.Item2;
            }
        }

        /// <summary>
        /// 指定した行をN倍
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="i">n倍する行</param>
        /// <param name="n">スケールファクタ</param>
        public static void DoublingRow(List<List<T>> matrix, int i, T n) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 指定した列をN倍
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="i">n倍する列</param>
        /// <param name="n">スケールファクタ</param>
        public static void DoublingColumn(List<List<T>> matrix, int i, T n) {
            throw new NotImplementedException();
        }

        static Tuple<T, T> SwapValue(T x, T y) {
            return Tuple.Create(y, x);
        }
    }
}
