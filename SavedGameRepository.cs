/**
 * 
 * My Sudoku 3.0
 * By Joseph King
 * August 29, 2013
 * 
 * SavedGameRepository.cs
 * 
 * This class defines the saved game list objects.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySudoku3_0
{
    /// <summary>
    /// This holds a reference to the games we want to serialize
    /// </summary>
    [Serializable()]
    public class SavedGameRepository : ISerializable
    {
        #region Fields
        // A private Field to hold the games
        private List<SudokuGame> repositorySavedGameList;
        #endregion

        #region Properties
        // A public property to hold the games
        public List<SudokuGame> RepositorySavedGameList
        {
            get { return this.repositorySavedGameList; }
            set { this.repositorySavedGameList = value; }
        }
        #endregion

        #region Constructors
        // A constructor used to access the class
        public SavedGameRepository()
        {
            repositorySavedGameList = new List<SudokuGame>();
        }

        // A constructor used to build the list from memory
        public SavedGameRepository(SerializationInfo info, StreamingContext context)
        {
            this.repositorySavedGameList = (List<SudokuGame>)info.GetValue("SavedGames.dat", typeof(List<SudokuGame>));
        }
        #endregion

        #region ISerializable Member
        // The ISerializable Member
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("SavedGames.dat", this.repositorySavedGameList);
        }
        #endregion
    }
}
