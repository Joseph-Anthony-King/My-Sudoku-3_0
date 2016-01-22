/**
 * 
 * My Sudoku 3.0
 * By Joseph King
 * August 29, 2013
 * 
 * Element.cs
 * 
 * The element class defines the elements in the sudoku matrix. 
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
    /// This class defines the elements of the sudoku matrix.
    /// </summary>
    [Serializable()]
    public class Element : ISerializable
    {
        #region Properties
        // This property gets and sets the element's value
        public int Number { get; set; }

        // This property gets and sets the element's display hint
        public bool DisplayHint { get; set; }

        // This property represents the user's certainity of their entry
        public bool Certain { get; set; }
        #endregion

        #region Constructors
        // The constructors
        public Element(int x, bool hint)
        {
            Number = x;
            DisplayHint = hint;
            Certain = false;
        }

        public Element(int x)
        {
            Number = x;
            DisplayHint = false;
            Certain = false;
        }

        public Element()
        {
            Number = 0;
            DisplayHint = false;
            Certain = false;
        }

        // ISeriazable Constructor
        public Element(SerializationInfo info, StreamingContext context)
        {
            this.Number = (int)info.GetValue("Number", typeof(int));
            this.DisplayHint = (bool)info.GetValue("DisplayHint", typeof(bool));
            this.Certain = (bool)info.GetValue("Certain", typeof(bool));
        }
        #endregion

        #region Element Methods
        // Override the ToString() method
        public override string ToString()
        {
            string s = Number.ToString();
            return s;
        }
        #endregion

        #region ISerializable Members
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Number", this.Number);
            info.AddValue("DisplayHint", this.DisplayHint);
            info.AddValue("Certain", this.Certain);
        }
        #endregion
    }
}
