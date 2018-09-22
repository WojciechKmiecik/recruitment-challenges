// -----------------------------------------------------------------------
// <copyright file="BitCounter.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Algorithms.CountingBits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PositiveBitCounter
    {
        public IEnumerable<int> Count(int input)
        {
            if (input < 0)
            {
                throw new ArgumentException();
            }
            if (input == 0)
            {
                return new int[] { 0 };
            }
            if (input == 1)
            {
                return new int[] { 1, 0 };
            }
            return countSetBitsLookupTable(input);
        }

        //  Brian Kernighan’s Alg - O(logn) - but wrong  position result
        // I left this code by the purpose, to present my thinking path. 
        static List<int> countSetBitsKernighan(int n)
        {
            List<int> retlist = new List<int>();
            int count = 0;
            //int pos = 0;

            while (n > 0)
            {
                n &= (n - 1);

                //if (n > 0) // calculate position   
                //{
                //    pos = Convert.ToInt32( Math.Log(n) / Math.Log(2));
                //}
                //else pos = 0;

                //retlist.Add(pos); 
                count++;
            }
            return retlist;
        }

        // lookup table idea - works when object will be a singleton and leaves variable could be calculated in constructor as static field.
        static List<int> countSetBitsLookupTable(int n)
        {
            var exponent = Math.Ceiling(Math.Log(n) / Math.Log(2));         // find closest number that will be power of 2, and ceil it
            var desiredTableSize = Convert.ToInt32(Math.Pow(2, exponent));

            int[][] leaves = new int[desiredTableSize][];                   // prepare result table
            for (int i = 0; i < desiredTableSize; ++i)
                leaves[i] = Enumerable.Range(0, 8)
                                      .Where(b => (i & (1 << b)) != 0)
                                      .Select(b => b)
                                      .ToArray();

            var searchedElement = leaves[n].ToList();
            List<int> retlist = new List<int>() { searchedElement.Count };   // prepare result
            retlist.AddRange(searchedElement);
            return retlist;
        }
    }
}