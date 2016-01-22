/**
 * 
 * My Sudoku 3.0
 * By Joseph King
 * August 29, 2013
 * 
 * SudokuUtilities.cs
 * 
 * This class defines utility methods used by the game.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MySudoku3_0
{
    /// <summary>
    /// The utilities class for the game
    /// </summary>
    public class SudokuUtilities
    {
        #region Random Number Generator
        /// <summary>
        /// Initiate a static random number generator
        /// </summary>
        public static Random generateRandomNumber = new Random();
        #endregion

        #region Shuffle<T>()
        /// <summary>
        /// This method shuffles elements in a list
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="list">Generic Type List</param>
        public static void Shuffle<T>(List<T> list)
        {
            var _randomShuffle = generateRandomNumber;

            for (int i = list.Count; i > 1; i--)
            {
                // Pick a random element to swap
                int j = _randomShuffle.Next(9);
                int k = _randomShuffle.Next(9);
                // Swap
                T tmp = list[j];
                list[j] = list[k];
                list[k] = tmp;
            }
        }
        #endregion

        #region ConvertStringArrayToString()
        /// <summary>
        /// Convert string arrays to strings
        /// </summary>
        /// <param name="array">String Array</param>
        /// <returns>String</returns>
        public static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string s in array)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
        #endregion

        #region CellIsCertain()
        public static void CellIsCertain(ref object o, Boolean certain)
        {
            TextBox tb = (TextBox)o;
            if (tb.IsReadOnly == false)
            {
                if (certain == true)
                    tb.Foreground = Brushes.Black;
                else
                    tb.Foreground = Brushes.SlateGray;
            }
        }
        #endregion

        #region cellIsValid()
        public static void CellIsValid(ref object o)
        {
            TextBox tb = (TextBox)o;
            int number;

            bool result = Int32.TryParse(tb.Text, out number);

            if (result)
            {
                if (number < 1 || number > 9)
                {
                    MessageBox.Show("Please enter a number between 1 through 9.");
                    tb.Text = "";
                }
            }
            else
            {
                if (tb.Text == "")
                { }
                else
                {
                    MessageBox.Show("Please enter a number between 1 through 9.");
                    tb.Text = "";
                }
            }
        }
        #endregion

        #region SudokuSolutionGenerator()
        /// <summary>
        /// Generates a random sudoku matrix
        /// </summary>
        /// <returns>List of Integers</returns>
        public static List<int> SudokuSolutionGenerator()
        {
            // The maximum number of iterations before the generator resets
            const int MAX_ITERATIONS = 1000000;

            // This int keeps track of the iterations
            int iterations;

            // Bool to determine if the matrix has been completed
            bool completed = false;

            // Bool to indicate if the maximum iterations have been reached
            bool maxIterationsReached;

            // Create a list to hold a sequence of nine numbers
            List<int> listOfNineNumbers = new List<int>();

            // The list of lists of int that is used for processing
            List<List<int>> sudokuMatrix = new List<List<int>>();

            // The list of int that is returned by the method
            List<int> result = new List<int>();

            // load the numbers
            for (int i = 1; i < 10; i++)
            {
                listOfNineNumbers.Add(i);
            }

            do
            {
                iterations = 0;

                maxIterationsReached = false;

                List<int> firstRow = listOfNineNumbers.ToList();

                Shuffle(firstRow);

                List<int> secondRow = listOfNineNumbers.ToList();

                SetSecondRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref secondRow, firstRow);

                List<int> thirdRow = listOfNineNumbers.ToList();

                if (maxIterationsReached == false)
                {
                    SetThirdRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref thirdRow, firstRow, secondRow);
                }

                List<int> firstColumn = new List<int>();

                List<int> secondColumn = new List<int>();

                List<int> thirdColumn = new List<int>();

                List<int> fourthColumn = new List<int>();

                List<int> fifthColumn = new List<int>();

                List<int> sixthColumn = new List<int>();

                List<int> seventhColumn = new List<int>();

                List<int> eighthColumn = new List<int>();

                List<int> ninthColumn = new List<int>();

                if (maxIterationsReached == false)
                {
                    SetColumns(ref firstColumn, ref secondColumn, ref thirdColumn, ref fourthColumn, ref fifthColumn,
                        ref sixthColumn, ref seventhColumn, ref eighthColumn, ref ninthColumn, firstRow, secondRow,
                        thirdRow);
                }

                List<int> fourthRow = listOfNineNumbers.ToList();

                if (maxIterationsReached == false)
                {
                    SetFourthRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref fourthRow, ref firstColumn,
                        ref secondColumn, ref thirdColumn, ref fourthColumn, ref fifthColumn, ref sixthColumn, ref seventhColumn,
                        ref eighthColumn, ref ninthColumn);
                }

                List<int> fifthRow = listOfNineNumbers.ToList();

                if (maxIterationsReached == false)
                {
                    SetFifthRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref fifthRow, ref firstColumn, ref secondColumn,
                        ref thirdColumn, ref fourthColumn, ref fifthColumn, ref sixthColumn, ref seventhColumn, ref eighthColumn,
                        ref ninthColumn, fourthRow);
                }

                List<int> sixthRow = listOfNineNumbers.ToList();

                if (maxIterationsReached == false)
                {
                    SetSixthRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref sixthRow, ref firstColumn, ref secondColumn,
                        ref thirdColumn, ref fourthColumn, ref fifthColumn, ref sixthColumn, ref seventhColumn, ref eighthColumn,
                        ref ninthColumn, fourthRow, fifthRow);
                }

                List<int> seventhRow = listOfNineNumbers.ToList();

                if (maxIterationsReached == false)
                {
                    SetSeventhRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref seventhRow, ref firstColumn, ref secondColumn,
                        ref thirdColumn, ref fourthColumn, ref fifthColumn, ref sixthColumn, ref seventhColumn, ref eighthColumn,
                        ref ninthColumn);
                }

                List<int> eighthRow = listOfNineNumbers.ToList();

                if (maxIterationsReached == false)
                {
                    SetEighthRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref eighthRow, ref firstColumn, ref secondColumn,
                        ref thirdColumn, ref fourthColumn, ref fifthColumn, ref sixthColumn, ref seventhColumn, ref eighthColumn,
                        ref ninthColumn, seventhRow);
                }

                List<int> ninthRow = listOfNineNumbers.ToList();

                if (maxIterationsReached == false)
                {
                    SetNinthRow(MAX_ITERATIONS, ref iterations, ref maxIterationsReached, ref ninthRow, ref firstColumn, ref secondColumn,
                        ref thirdColumn, ref fourthColumn, ref fifthColumn, ref sixthColumn, ref seventhColumn, ref eighthColumn,
                        ref ninthColumn, seventhRow, eighthRow);
                }

                if (maxIterationsReached == false)
                {
                    AddRowsToSudokuMatrix(ref sudokuMatrix, ref firstRow, ref secondRow, ref thirdRow, ref fourthRow, ref fifthRow,
                        ref sixthRow, ref seventhRow, ref eighthRow, ref ninthRow);

                    completed = true;
                }
            }
            while (completed == false);

            // Return the list of int lists
            return result = sudokuMatrix.SelectMany(row => row).ToList();
        }

        #region SetSecondRow()
        /// <summary>
        /// This method sets the values of the second row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="_secondRow">2nd Row passed by reference</param>
        /// <param name="_firstRow">3rd Row</param>
        private static void SetSecondRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> _secondRow, List<int> _firstRow)
        {
            do
            {
                Shuffle(_secondRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (_firstRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Take(3).OrderBy(n => n))) ||
                (_firstRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (_firstRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(_secondRow.Skip(6).Take(3).OrderBy(n => n)))
                );
        }
        #endregion

        #region SetThirdRow()
        /// <summary>
        /// This method sets the values of the third row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="thirdRow">3rd Row passed by reference</param>
        /// <param name="firstRow">1st Row</param>
        /// <param name="secondRow">2nd Row</param>
        private static void SetThirdRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> thirdRow, List<int> firstRow, List<int> secondRow)
        {
            do
            {
                Shuffle(thirdRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (firstRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(thirdRow.Take(3).OrderBy(n => n))) ||
                (secondRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(thirdRow.Take(3).OrderBy(n => n))) ||
                (firstRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(thirdRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (secondRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(thirdRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (firstRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(thirdRow.Skip(6).Take(3).OrderBy(n => n))) ||
                (secondRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(thirdRow.Skip(6).Take(3).OrderBy(n => n)))
                );
        }
        #endregion

        #region SetColumns()
        /// <summary>
        /// This method creates the columns used to test values between regions.
        /// </summary>
        /// <param name="firstColumn">1st Column passed by reference</param>
        /// <param name="secondColumn">2nd Column passed by reference</param>
        /// <param name="thirdColumn">3rd Column passed by reference</param>
        /// <param name="fourthColumn">4th Column passed by reference</param>
        /// <param name="fifthColumn">5th Column passed by reference</param>
        /// <param name="sixthColumn">6th Column passed by reference</param>
        /// <param name="seventhColumn">7th Column passed by reference</param>
        /// <param name="eighthColumn">8th Column passed by reference</param>
        /// <param name="ninthColumn">9th Column passed by reference</param>
        /// <param name="firstRow">1st Row</param>
        /// <param name="secondRow">2nd Row</param>
        /// <param name="thirdRow">3rd Row</param>
        private static void SetColumns(ref List<int> firstColumn, ref List<int> secondColumn, ref List<int> thirdColumn,
            ref List<int> fourthColumn, ref List<int> fifthColumn, ref List<int> sixthColumn, ref List<int> seventhColumn,
            ref List<int> eighthColumn, ref List<int> ninthColumn, List<int> firstRow, List<int> secondRow, List<int> thirdRow)
        {
            firstColumn.Add(firstRow[0]);
            firstColumn.Add(secondRow[0]);
            firstColumn.Add(thirdRow[0]);

            secondColumn.Add(firstRow[1]);
            secondColumn.Add(secondRow[1]);
            secondColumn.Add(thirdRow[1]);

            thirdColumn.Add(firstRow[2]);
            thirdColumn.Add(secondRow[2]);
            thirdColumn.Add(thirdRow[2]);

            fourthColumn.Add(firstRow[3]);
            fourthColumn.Add(secondRow[3]);
            fourthColumn.Add(thirdRow[3]);

            fifthColumn.Add(firstRow[4]);
            fifthColumn.Add(secondRow[4]);
            fifthColumn.Add(thirdRow[4]);

            sixthColumn.Add(firstRow[5]);
            sixthColumn.Add(secondRow[5]);
            sixthColumn.Add(thirdRow[5]);

            seventhColumn.Add(firstRow[6]);
            seventhColumn.Add(secondRow[6]);
            seventhColumn.Add(thirdRow[6]);

            eighthColumn.Add(firstRow[7]);
            eighthColumn.Add(secondRow[7]);
            eighthColumn.Add(thirdRow[7]);

            ninthColumn.Add(firstRow[8]);
            ninthColumn.Add(secondRow[8]);
            ninthColumn.Add(thirdRow[8]);
        }
        #endregion

        #region SetFourthRow()
        /// <summary>
        /// This method set the values of the fourth row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="fourthRow">4th Row passed by reference</param>
        /// <param name="firstColumn">1st Column passed by reference</param>
        /// <param name="secondColumn">2nd Column passed by reference</param>
        /// <param name="thirdColumn">3rd Column passed by reference</param>
        /// <param name="fourthColumn">4th Column passed by reference</param>
        /// <param name="fifthColumn">5th Column passed by reference</param>
        /// <param name="sixthColumn">6th Column passed by reference</param>
        /// <param name="seventhColumn">7th Column passed by reference</param>
        /// <param name="eighthColumn">8th Column passed by reference</param>
        /// <param name="ninthColumn">9th Column passed by reference</param>
        private static void SetFourthRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> fourthRow,
            ref List<int> firstColumn, ref List<int> secondColumn, ref List<int> thirdColumn, ref List<int> fourthColumn,
            ref List<int> fifthColumn, ref List<int> sixthColumn, ref List<int> seventhColumn, ref List<int> eighthColumn,
            ref List<int> ninthColumn)
        {
            do
            {
                Shuffle(fourthRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (firstColumn.Contains(fourthRow[0])) ||
                (secondColumn.Contains(fourthRow[1])) ||
                (thirdColumn.Contains(fourthRow[2])) ||
                (fourthColumn.Contains(fourthRow[3])) ||
                (fifthColumn.Contains(fourthRow[4])) ||
                (sixthColumn.Contains(fourthRow[5])) ||
                (seventhColumn.Contains(fourthRow[6])) ||
                (eighthColumn.Contains(fourthRow[7])) ||
                (ninthColumn.Contains(fourthRow[8]))
                );

            firstColumn.Add(fourthRow[0]);
            secondColumn.Add(fourthRow[1]);
            thirdColumn.Add(fourthRow[2]);
            fourthColumn.Add(fourthRow[3]);
            fifthColumn.Add(fourthRow[4]);
            sixthColumn.Add(fourthRow[5]);
            seventhColumn.Add(fourthRow[6]);
            eighthColumn.Add(fourthRow[7]);
            ninthColumn.Add(fourthRow[8]);
        }
        #endregion

        #region SetFifthRow()
        /// <summary>
        /// This method sets the values of the fifth row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="fifthRow">5th Row passed by reference</param>
        /// <param name="firstColumn">1st Column passed by reference</param>
        /// <param name="secondColumn">2nd Column passed by reference</param>
        /// <param name="thirdColumn">3rd Column passed by reference</param>
        /// <param name="fourthColumn">4th Column passed by reference</param>
        /// <param name="fifthColumn">5th Column passed by reference</param>
        /// <param name="sixthColumn">6th Column passed by reference</param>
        /// <param name="seventhColumn">7th Column passed by reference</param>
        /// <param name="eighthColumn">8th Column passed by reference</param>
        /// <param name="ninthColumn">9th Column passed by reference</param>
        /// <param name="fourthRow">4th Row</param>
        private static void SetFifthRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> fifthRow,
            ref List<int> firstColumn, ref List<int> secondColumn, ref List<int> thirdColumn, ref List<int> fourthColumn,
            ref List<int> fifthColumn, ref List<int> sixthColumn, ref List<int> seventhColumn, ref List<int> eighthColumn,
            ref List<int> ninthColumn, List<int> fourthRow)
        {
            do
            {
                Shuffle(fifthRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (firstColumn.Contains(fifthRow[0])) ||
                (secondColumn.Contains(fifthRow[1])) ||
                (thirdColumn.Contains(fifthRow[2])) ||
                (fourthColumn.Contains(fifthRow[3])) ||
                (fifthColumn.Contains(fifthRow[4])) ||
                (sixthColumn.Contains(fifthRow[5])) ||
                (seventhColumn.Contains(fifthRow[6])) ||
                (eighthColumn.Contains(fifthRow[7])) ||
                (ninthColumn.Contains(fifthRow[8])) ||
                (fourthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(fifthRow.Take(3).OrderBy(n => n))) ||
                (fourthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(fifthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (fourthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(fifthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            firstColumn.Add(fifthRow[0]);
            secondColumn.Add(fifthRow[1]);
            thirdColumn.Add(fifthRow[2]);
            fourthColumn.Add(fifthRow[3]);
            fifthColumn.Add(fifthRow[4]);
            sixthColumn.Add(fifthRow[5]);
            seventhColumn.Add(fifthRow[6]);
            eighthColumn.Add(fifthRow[7]);
            ninthColumn.Add(fifthRow[8]);
        }
        #endregion

        #region SetSixthRow()
        /// <summary>
        /// This method sets the values of the sixth row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="sixthRow">6th Row passed by Reference</param>
        /// <param name="firstColumn">1st Column passed by reference</param>
        /// <param name="secondColumn">2nd Column passed by reference</param>
        /// <param name="thirdColumn">3rd Column passed by reference</param>
        /// <param name="fourthColumn">4th Column passed by reference</param>
        /// <param name="fifthColumn">5th Column passed by reference</param>
        /// <param name="sixthColumn">6th Column passed by reference</param>
        /// <param name="seventhColumn">7th Column passed by reference</param>
        /// <param name="eighthColumn">8th Column passed by reference</param>
        /// <param name="ninthColumn">9th Column passed by reference</param>
        /// <param name="fourthRow">4th Row</param>
        /// <param name="fifthRow">5th Row</param>
        private static void SetSixthRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> sixthRow,
            ref List<int> firstColumn, ref List<int> secondColumn, ref List<int> thirdColumn, ref List<int> fourthColumn,
            ref List<int> fifthColumn, ref List<int> sixthColumn, ref List<int> seventhColumn, ref List<int> eighthColumn,
            ref List<int> ninthColumn, List<int> fourthRow, List<int> fifthRow)
        {
            do
            {
                Shuffle(sixthRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (firstColumn.Contains(sixthRow[0])) ||
                (secondColumn.Contains(sixthRow[1])) ||
                (thirdColumn.Contains(sixthRow[2])) ||
                (fourthColumn.Contains(sixthRow[3])) ||
                (fifthColumn.Contains(sixthRow[4])) ||
                (sixthColumn.Contains(sixthRow[5])) ||
                (seventhColumn.Contains(sixthRow[6])) ||
                (eighthColumn.Contains(sixthRow[7])) ||
                (ninthColumn.Contains(sixthRow[8])) ||
                (fourthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(sixthRow.Take(3).OrderBy(n => n))) ||
                (fifthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(sixthRow.Take(3).OrderBy(n => n))) ||
                (fourthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(sixthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (fifthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(sixthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (fourthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(sixthRow.Skip(6).Take(3).OrderBy(n => n))) ||
                (fifthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(sixthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            firstColumn.Add(sixthRow[0]);
            secondColumn.Add(sixthRow[1]);
            thirdColumn.Add(sixthRow[2]);
            fourthColumn.Add(sixthRow[3]);
            fifthColumn.Add(sixthRow[4]);
            sixthColumn.Add(sixthRow[5]);
            seventhColumn.Add(sixthRow[6]);
            eighthColumn.Add(sixthRow[7]);
            ninthColumn.Add(sixthRow[8]);
        }
        #endregion

        #region SetSeventhRow()
        /// <summary>
        /// This method sets the values of the seventh row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="seventhRow">7th Row passed by reference</param>
        /// <param name="firstColumn">1st Column passed by reference</param>
        /// <param name="secondColumn">2nd Column passed by reference</param>
        /// <param name="thirdColumn">3rd Column passed by reference</param>
        /// <param name="fourthColumn">4th Column passed by reference</param>
        /// <param name="fifthColumn">5th Column passed by reference</param>
        /// <param name="sixthColumn">6th Column passed by reference</param>
        /// <param name="seventhColumn">7th Column passed by reference</param>
        /// <param name="eighthColumn">8th Column passed by reference</param>
        /// <param name="ninthColumn">9th Column passed by reference</param>
        private static void SetSeventhRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> seventhRow,
            ref List<int> firstColumn, ref List<int> secondColumn, ref List<int> thirdColumn, ref List<int> fourthColumn,
            ref List<int> fifthColumn, ref List<int> sixthColumn, ref List<int> seventhColumn, ref List<int> eighthColumn,
            ref List<int> ninthColumn)
        {
            do
            {
                Shuffle(seventhRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (firstColumn.Contains(seventhRow[0])) ||
                (secondColumn.Contains(seventhRow[1])) ||
                (thirdColumn.Contains(seventhRow[2])) ||
                (fourthColumn.Contains(seventhRow[3])) ||
                (fifthColumn.Contains(seventhRow[4])) ||
                (sixthColumn.Contains(seventhRow[5])) ||
                (seventhColumn.Contains(seventhRow[6])) ||
                (eighthColumn.Contains(seventhRow[7])) ||
                (ninthColumn.Contains(seventhRow[8]))
                );

            firstColumn.Add(seventhRow[0]);
            secondColumn.Add(seventhRow[1]);
            thirdColumn.Add(seventhRow[2]);
            fourthColumn.Add(seventhRow[3]);
            fifthColumn.Add(seventhRow[4]);
            sixthColumn.Add(seventhRow[5]);
            seventhColumn.Add(seventhRow[6]);
            eighthColumn.Add(seventhRow[7]);
            ninthColumn.Add(seventhRow[8]);
        }
        #endregion

        #region SetEighthRow()
        /// <summary>
        /// This method sets the values of the eighth row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="eighthRow">8th Row passed by reference</param>
        /// <param name="firstColumn">1st Column passed by reference</param>
        /// <param name="secondColumn">2nd Column passed by reference</param>
        /// <param name="thirdColumn">3rd Column passed by reference</param>
        /// <param name="fourthColumn">4th Column passed by reference</param>
        /// <param name="fifthColumn">5th Column passed by reference</param>
        /// <param name="sixthColumn">6th Column passed by reference</param>
        /// <param name="seventhColumn">7th Column passed by reference</param>
        /// <param name="eighthColumn">8th Column passed by reference</param>
        /// <param name="ninthColumn">9th Column passed by reference</param>
        /// <param name="seventhRow">7th Row</param>
        private static void SetEighthRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> eighthRow,
            ref List<int> firstColumn, ref List<int> secondColumn, ref List<int> thirdColumn, ref List<int> fourthColumn,
            ref List<int> fifthColumn, ref List<int> sixthColumn, ref List<int> seventhColumn, ref List<int> eighthColumn,
            ref List<int> ninthColumn, List<int> seventhRow)
        {
            do
            {
                Shuffle(eighthRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (firstColumn.Contains(eighthRow[0])) ||
                (secondColumn.Contains(eighthRow[1])) ||
                (thirdColumn.Contains(eighthRow[2])) ||
                (fourthColumn.Contains(eighthRow[3])) ||
                (fifthColumn.Contains(eighthRow[4])) ||
                (sixthColumn.Contains(eighthRow[5])) ||
                (seventhColumn.Contains(eighthRow[6])) ||
                (eighthColumn.Contains(eighthRow[7])) ||
                (ninthColumn.Contains(eighthRow[8])) ||
                (seventhRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(eighthRow.Take(3).OrderBy(n => n))) ||
                (seventhRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(eighthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (seventhRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(eighthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            firstColumn.Add(eighthRow[0]);
            secondColumn.Add(eighthRow[1]);
            thirdColumn.Add(eighthRow[2]);
            fourthColumn.Add(eighthRow[3]);
            fifthColumn.Add(eighthRow[4]);
            sixthColumn.Add(eighthRow[5]);
            seventhColumn.Add(eighthRow[6]);
            eighthColumn.Add(eighthRow[7]);
            ninthColumn.Add(eighthRow[8]);
        }
        #endregion

        #region SetNinthRow()
        /// <summary>
        /// This method sets the values of the ninth row.
        /// </summary>
        /// <param name="MAX_ITERATIONS">Maximum Iterations</param>
        /// <param name="iterations">Count of Iterations</param>
        /// <param name="maxIterationsReached">Boolean indication if the loop will continue</param>
        /// <param name="ninthRow">9th Row passed by reference</param>
        /// <param name="firstColumn">1st Column passed by reference</param>
        /// <param name="secondColumn">2nd Column passed by reference</param>
        /// <param name="thirdColumn">3rd Column passed by reference</param>
        /// <param name="fourthColumn">4th Column passed by reference</param>
        /// <param name="fifthColumn">5th Column passed by reference</param>
        /// <param name="sixthColumn">6th Column passed by reference</param>
        /// <param name="seventhColumn">7th Column passed by reference</param>
        /// <param name="eighthColumn">8th Column passed by reference</param>
        /// <param name="ninthColumn">9th Column passed by reference</param>
        /// <param name="seventhRow">7th Row</param>
        /// <param name="eighthRow">8th Row</param>
        private static void SetNinthRow(int MAX_ITERATIONS, ref int iterations, ref bool maxIterationsReached, ref List<int> ninthRow,
            ref List<int> firstColumn, ref List<int> secondColumn, ref List<int> thirdColumn, ref List<int> fourthColumn,
            ref List<int> fifthColumn, ref List<int> sixthColumn, ref List<int> seventhColumn, ref List<int> eighthColumn,
            ref List<int> ninthColumn, List<int> seventhRow, List<int> eighthRow)
        {
            do
            {
                Shuffle(ninthRow);
                ++iterations;

                if (iterations == MAX_ITERATIONS)
                {
                    maxIterationsReached = true;
                    break;
                }
            }
            while (
                (firstColumn.Contains(ninthRow[0])) ||
                (secondColumn.Contains(ninthRow[1])) ||
                (thirdColumn.Contains(ninthRow[2])) ||
                (fourthColumn.Contains(ninthRow[3])) ||
                (fifthColumn.Contains(ninthRow[4])) ||
                (sixthColumn.Contains(ninthRow[5])) ||
                (seventhColumn.Contains(ninthRow[6])) ||
                (eighthColumn.Contains(ninthRow[7])) ||
                (ninthColumn.Contains(ninthRow[8])) ||
                (seventhRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(ninthRow.Take(3).OrderBy(n => n))) ||
                (eighthRow.Take(3).OrderBy(n => n).ContainsAnySimilarElements(ninthRow.Take(3).OrderBy(n => n))) ||
                (seventhRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(ninthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (eighthRow.Skip(3).Take(3).OrderBy(n => n).ContainsAnySimilarElements(ninthRow.Skip(3).Take(3).OrderBy(n => n))) ||
                (seventhRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(ninthRow.Skip(6).Take(3).OrderBy(n => n))) ||
                (eighthRow.Skip(6).Take(3).OrderBy(n => n).ContainsAnySimilarElements(ninthRow.Skip(6).Take(3).OrderBy(n => n)))
                );

            firstColumn.Add(ninthRow[0]);
            secondColumn.Add(ninthRow[1]);
            thirdColumn.Add(ninthRow[2]);
            fourthColumn.Add(ninthRow[3]);
            fifthColumn.Add(ninthRow[4]);
            sixthColumn.Add(ninthRow[5]);
            seventhColumn.Add(ninthRow[6]);
            eighthColumn.Add(ninthRow[7]);
            ninthColumn.Add(ninthRow[8]);
        }
        #endregion

        #region AddRowsToSudokuMatrix()
        /// <summary>
        /// This method combines the rows into the sudoku matrix.
        /// </summary>
        /// <param name="sudokuMatrix">Sudoku matrix passed by reference</param>
        /// <param name="firstRow">1st Row passed by reference</param>
        /// <param name="secondRow">2nd Row passed by reference</param>
        /// <param name="thirdRow">3rd Row passed by reference</param>
        /// <param name="fourthRow">4th Row passed by reference</param>
        /// <param name="fifthRow">5th Row passed by reference</param>
        /// <param name="sixthRow">6th Row passed by reference</param>
        /// <param name="seventhRow">7th Row passed by reference</param>
        /// <param name="eighthRow">8th Row passed by reference</param>
        /// <param name="ninthRow">9th Row passed by reference</param>
        private static void AddRowsToSudokuMatrix(ref List<List<int>> sudokuMatrix, ref List<int> firstRow, ref List<int> secondRow,
            ref List<int> thirdRow, ref List<int> fourthRow, ref List<int> fifthRow, ref List<int> sixthRow, ref List<int> seventhRow,
            ref List<int> eighthRow, ref List<int> ninthRow)
        {
            sudokuMatrix.Add(firstRow);
            sudokuMatrix.Add(secondRow);
            sudokuMatrix.Add(thirdRow);
            sudokuMatrix.Add(fourthRow);
            sudokuMatrix.Add(fifthRow);
            sudokuMatrix.Add(sixthRow);
            sudokuMatrix.Add(seventhRow);
            sudokuMatrix.Add(eighthRow);
            sudokuMatrix.Add(ninthRow);
        }
        #endregion
        #endregion
    }
}
