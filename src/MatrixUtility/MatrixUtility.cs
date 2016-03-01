using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace MatrixUtility
{
    public static class Functions
    {
        public static double GetDeterminant3(List<List<double>> A) {
            Contract.Requires(A.Count == 3);
            Contract.Requires(A[0].Count == 3);

            /* Sarrus' rule */
            double det
                = A[0][0] * A[1][1] * A[2][2]
                + A[1][0] * A[2][1] * A[0][2]
                + A[2][0] * A[0][1] * A[1][2]
                - A[0][0] * A[1][2] * A[2][1]
                - A[0][1] * A[1][0] * A[2][2]
                - A[0][2] * A[1][1] * A[2][0];
            return det;
        }
    }
}
