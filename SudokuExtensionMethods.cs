/**
 * 
 * My Sudoku 3.0
 * By Joseph King
 * August 29, 2013
 * 
 * SudokuExtensionMethods.cs
 * 
 * This class defines extension methods used by the sudoku game objects.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MySudoku3_0
{
    #region ContainsAnySimilarElements
    public static class SudokuExtensions
    {
        /// <summary>
        /// Compares two lists to see if they have any similar elements
        /// </summary>
        /// <param name="aList">Invocation Integer List</param>
        /// <param name="bList">parameter Integer List</param>
        /// <returns>Boolean</returns>
        public static bool ContainsAnySimilarElements(this IEnumerable<int> aList, IEnumerable<int> bList)
        {
            bool result = false;

            foreach (int a in aList)
            {
                if (bList.Contains(a))
                {
                    result = true;
                }
            }

            return result;
        }
    }
    #endregion

    #region TryParse
    public static class SudokuStringExtensions
    {
        /// <summary>
        /// Verifies if a string can be parsed to an int
        /// </summary>
        public static bool TryParse(this string source)
        {
            int number;
            bool result;

            bool test = Int32.TryParse(source, out number);

            if (test == true)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
    #endregion

    #region IndexRange
    public static class SudokuLinqExtension
    {
        /// <summary>
        /// Returns a sublist of a list
        /// </summary>
        /// <typeparam name="TSource">Generic Type</typeparam>
        /// <param name="source">Generic Source</param>
        /// <param name="fromIndex">Starting Index</param>
        /// <param name="toIndex">Final Index</param>
        /// <returns></returns>
        public static IEnumerable<TSource> ReturnSublist<TSource>(
            this IList<TSource> source,
            int fromIndex,
            int toIndex)
        {
            int currIndex = fromIndex;
            while (currIndex <= toIndex)
            {
                yield return source[currIndex];
                currIndex++;
            }
        }
    }
    #endregion
}
