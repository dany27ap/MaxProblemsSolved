using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SolutionProblem {
    public class NumberWithSquareSumOfSquareDivisorsFinder {
        public int[] Find(int start, int end)
        {
            ArrayList temp = new ArrayList();
            for (int i = start; i <= end; ++i) {
                int j = ReturnElementForVector(i);
                if (j > 0) {
                    temp.Add(j);
                }
            }

            int[] finalVectorResult = new int[temp.Count];
            temp.CopyTo(finalVectorResult);
            return finalVectorResult;
        }
        
        public static int ReturnElementForVector(int n)
        {
            List<int> listOfDivisor = new List<int>();
            for (int i = 1; i <= n; ++i)
            {
                if (n % i == 0)
                    listOfDivisor.Add(i);
            }
            var squaredNumber = listOfDivisor.Sum(x => x * x);
            if (Math.Sqrt(squaredNumber) % 1 == 0)
                return n;
            return 0;
        }
    }
}