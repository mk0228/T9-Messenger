/**
 * Model.cs
 * Model for the T9 Messenger
 * @author: Mahlakshmy Krishnamoorhty(mk4309)
 * 
 * */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Model
    {
        long lastTime = 0;//last time clicked
        char[][] numpad = new char[11][];//setting the characters
        int i = 0;
        long longWait = 1000;//time to wait

        // setting the dictionary with the character and number
        Dictionary<char, int> mapping = new Dictionary<char, int>{{'a', 2}, {'b', 2}, {'c', 2},
                                         {'d', 3}, {'e', 3}, {'f', 3},
                                         {'g', 4}, {'h', 4}, {'i', 4},
                                         {'j', 5}, {'k', 5}, {'l', 5},
                                         {'m', 6}, {'n', 6}, {'o', 6},
                                         {'p', 7}, {'q', 7}, {'r', 7}, {'s', 7},
                                         {'t', 8}, {'u', 8}, {'v', 8},
                                         {'w', 9},{ 'x', 9}, {'y', 9}, {'z', 9}};
        //to store each word and the corresponding key
        Dictionary<string, string> d = new Dictionary<string, string>();

        /// <summary>
        /// Constructor to initialise values
        /// </summary>
        public Model()
        {
            //setting the character arrays for each of them 
            char[] _2 = { 'a', 'b', 'c', '2' };
            char[] _3 = { 'd', 'e', 'f', '3' };
            char[] _4 = { 'g', 'h', 'i', '4' };
            char[] _5 = { 'j', 'k', 'l', '5' };
            char[] _6 = { 'm', 'n', 'o', '6' };
            char[] _7 = { 'p', 'q', 'r', 's', '7' };
            char[] _8 = { 't', 'u', 'v', '8' };
            char[] _9 = { 'w', 'x', 'y', 'z', '9' };
            char[] _10 = { '0', '~' };

            numpad[2] = _2;
            numpad[3] = _3;
            numpad[4] = _4;
            numpad[5] = _5;
            numpad[6] = _6;
            numpad[7] = _7;
            numpad[8] = _8;
            numpad[9] = _9;
            numpad[0] = _10;

            //reading the file 
            string[] lines = System.IO.File.ReadAllLines("english-words.txt");
            //adding the words to the dictionary
            foreach (string line in lines)
            {
                d.Add(line, getKey(line));
            }
        }

        /// <summary>
        /// to generate key for each word
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string getKey(string line)
        {
            string key = "";
            for (int i = 0; i < line.Length; i++)
            {
                key += mapping[line[i]];
            }
            return key;
        }
        /// <summary>
        /// to find the character to be returned depending on the button clicked and time
        /// </summary>
        /// <param name="curTime"></param>
        /// <param name="tagvalue"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public string calcTime(long curTime, int tagvalue, string text)
        {
            // to check the wait time
            if (lastTime == 0 || curTime - lastTime > longWait)
            {
                i = 0;
                lastTime = curTime;
                // return the character to be displayed
                return text + numpad[tagvalue][i];
            }
            else
            {
                i = (i + 1) % numpad[tagvalue].Length;
                lastTime = curTime;
                //return the character to be displayed
                return text.Substring(0, text.Length - 1) + numpad[tagvalue][i];
            }
        }

        /// <summary>
        /// to find the predicted words
        /// </summary>
        /// <param name="EnteredText"></param>
        /// <returns></returns>
        public List<string> PredictedWords(string EnteredText)
        {
            List<string> temp = new List<string>();//predicted words

            //finding the list of words for the entered text
            var result =
                    from words in d
                    where words.Value.Equals((EnteredText))
                    select words.Key;

            temp.AddRange(result);

            //checking if the list has any words
            if (temp.Count == 0)
            {
                //finding the list of words for entered text
                var result1 =
                    from words in d
                    where words.Value.StartsWith((EnteredText))
                    select words.Key;

                temp.AddRange(result1);

            }

            List<string> PredictedWord = new List<string>();//predicted words

            #region predicting

            //checking the length to find the number of words to be returned
            if ((EnteredText.Length) == 1)
            {
                foreach (string word in temp)
                {
                    if (word.Length <= 3)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 2
            else if ((EnteredText.Length) == 2)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 2 && word.Length <= 4)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 3
            else if ((EnteredText.Length) == 3)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 3 && word.Length <= 5)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 4
            else if ((EnteredText.Length) == 4)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 4 && word.Length <= 7)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 5
            else if ((EnteredText.Length) == 5)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 5 && word.Length <= 8)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 6
            else if ((EnteredText.Length) == 6)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 6 && word.Length <= 9)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 7
            else if ((EnteredText.Length) == 7)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 7 && word.Length <= 10)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 8
            else if ((EnteredText.Length) == 8)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 8 && word.Length <= 11)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 9
            else if ((EnteredText.Length) == 9)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 9 && word.Length <= 12)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 10
            else if ((EnteredText.Length) == 10)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 10 && word.Length <= 14)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 11
            else if ((EnteredText.Length) == 11)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 11 && word.Length <= 16)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 12
            else if ((EnteredText.Length) == 12)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 12 && word.Length <= 17)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 13
            else if ((EnteredText.Length) == 13)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 13 && word.Length <= 18)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 14
            else if ((EnteredText.Length) == 14)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 14 && word.Length <= 19)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            //adding words predicted when length is 15 and more
            else if ((EnteredText.Length) >= 15)
            {
                foreach (string word in temp)
                {
                    if (word.Length >= 15)
                    {
                        PredictedWord.Add(word);
                    }
                }
            }
            #endregion predicting

            return PredictedWord.Take<string>(8).ToList<string>();
        }
    }
}
