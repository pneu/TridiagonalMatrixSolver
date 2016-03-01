using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace TrigonalSolver
{
    public static class GaussianElimination
    {
        /// <summary>
        /// Solve Ax = b where A is Trigonal Matrix.
        /// <para>A must be square matrix.</para>
        /// </summary>
        /// <param name="A">A of Ax = b</param>
        /// <param name="b">b of Ax = b</param>
        /// <remarks>Aが三重対角行列であることを呼び出し側で保証してください。</remarks>
        /// <see cref="www-mupf.mech.eng.osaka-u.ac.jp/jugyo/12-2.pdf"/>
        public static void Solve(List<List<double>> A, List<double> b) {
            Contract.Requires(A.Count >= 3);
            Contract.Requires(A[0].Count == A.Count);
            var N = A[0].Count;

            Action<int, Func<bool>> scan = (i, guard) => {
                /* 0行目/A00を行い、0行目の対角成分を1にする */
                var k = A[i][i];
                for (int j = 0; j < N; ++j) {
                    A[i][j] /= k;
                }
                b[i] /= k;

                /* 最後の1行だけは次の行が無いため減算しない */
                if (guard()) {
                    /* 1行目 - A10 * 0行目を行い、1行目の左成分を0にする */
                    var l = A[i + 1][i];
                    for (int j = 0; j < N; ++j) {
                        A[i + 1][j] -= l * A[i][j];
                    }
                    b[i + 1] -= l * b[i];
                }
            };

            Action<int, Func<bool>> scanrev = (i, guard) => {
                /* 最後の1行だけは次の行が無いため減算しない */
                if (guard()) {
                    /* 1行目 - A10 * 0行目を行い、1行目の左成分を0にする */
                    var l = A[i - 1][i];
                    for (int j = 0; j < N; ++j) {
                        A[i - 1][j] -= l * A[i][j];
                    }
                    b[i - 1] -= l * b[i];
                }
            };

            /* 若番インデックスから老番へ */
            for (int x = 0; x < N; ++x) {
                scan(x, () => x < N - 1);
            }

            /* 老番インデックスから若番へ */
            for (int x = N - 1; x >= 0; --x) {
                scanrev(x, () => x > 0);
            }
        }
    }
}