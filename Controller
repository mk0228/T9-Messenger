/**
 * Controller.cs
 * Controller for the T9 Messenger
 * @author: Mahlakshmy Krishnamoorhty(mk4309)
 * 
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lab2
{
    /// <summary>
    /// Controller class for T9 messenger
    /// </summary>
    class Controller
    {
        Model m;
        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public Controller()
        {
            m = new Model();
        }

        /// <summary>
        /// to return the character to be printed by calling model
        /// </summary>
        /// <param name="time"></param>
        /// <param name="tagvalue"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public string returnTime(long time, int tagvalue, string text)
        {
            return m.calcTime(time, tagvalue, text);
        }

        /// <summary>
        /// to return the list of predicted words
        /// </summary>
        /// <param name="EnteredText"></param>
        /// <returns></returns>
        public List<string> GetPredictedWord(string EnteredText)
        {
            return m.PredictedWords(EnteredText);
        }
    }
}
