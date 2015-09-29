/**
 * MainWidow.xaml.cs
 * View of T9 Messenger
 * @author Mahalakshmy Krihnamoorthy(mk4309)
 * */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller c;
        string val; //to store the character to appear
        string[] words; //to store each word entered
        string word; // to store the word
        List<string> result = new List<string>();// to store the predicted words
        string _key; //to find the button clicked
        int count = 0;

        /// <summary>
        /// Constructor to initialize values
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            c = new Controller();
        }

        /// <summary>
        /// Function for handling the  button clicks on button 1
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            // Display '1' on button click
            this.insertext.Text += "1";
        }

        /// <summary>
        /// Function for handling the  button clicks on button 2
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.two.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {
                _key += "2";
                count = 0;
                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');
                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "a";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "a";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";

                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        //to display first word
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        //find length of entered word
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        //entering hyphen for the word
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button 3
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.three.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {
                _key += "3";
                count = 0;
                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');

                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "d";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "d";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";

                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button 4
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            _key += "4";
            count = 0;
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.four1.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {
                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');

                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "g";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "g";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";
                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button 5
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            _key += "5";
            count = 0;
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.five.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {
                // this.insertext.Text += "j";
                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');
                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "j";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "j";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";

                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        //find length of entered word
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button 6
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            _key += "6";
            count = 0;
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.six.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {

                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');
                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "m";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "m";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";
                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        //find length of entered word
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button 7
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            _key += "7";
            count = 0;
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.seven.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {
                // this.insertext.Text += "p";
                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');
                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "p";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "p";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";
                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        //find length of entered word
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button 8
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            _key += "8";
            count = 0;
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.eight.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {

                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');
                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "t";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "t";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";

                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        //find length of entered word
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }

        }

        /// <summary>
        /// Function for handling the  button clicks on button 9
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            _key += "9";
            count = 0;
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.nine.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {
                // this.insertext.Text += "a";
                //store each word in the sentence separated by space
                words = this.insertext.Text.Split(' ');

                //check whether it is first word in the sentence
                if (words[words.Length - 1] == "")
                {
                    //display the character
                    this.insertext.Text += "w";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                }

                else
                {
                    //display the character
                    this.insertext.Text += "w";
                    //storing each word
                    words = this.insertext.Text.Split(' ');
                    //obtaining the first word
                    word = words[words.Length - 1];
                    //calling the controller to get the list of words predicted
                    result = c.GetPredictedWord(_key);
                    string previousText = "";

                    //displaying the predicted words
                    if (result.Count != 0)
                    {
                        if (words.Length == 1)
                        {
                            this.insertext.Text = result[0];
                        }
                        else
                        {
                            for (int i = 0; i < words.Length - 1; i++)
                            {
                                previousText = previousText + words[i] + " ";
                            }
                            this.insertext.Text = previousText + result[0];
                        }
                    }
                    //if the list of predicted words is zero display all '-'
                    if (result.Count == 0)
                    {
                        //find length of entered word
                        int length = this.insertext.Text.Length;
                        string hyphen = "";
                        for (int i = 0; i <= length - 1; i++)
                        {
                            hyphen += "-";
                        }
                        this.insertext.Text = hyphen;
                    }
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button *
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_ClickBackspace(object sender, RoutedEventArgs e)
        {
            //to delete the previous character
            this.insertext.Text = this.insertext.Text.Substring(0, this.insertext.Text.Length - 1);
            if (_key != "")
            {
                _key = _key.Substring(0, _key.Length - 1);
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button 0
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_ClickTilde(object sender, RoutedEventArgs e)
        {
            //to check if in predictive mode or not
            if (chkbox.IsChecked.Equals(false))
            {
                //this.insertext.Text += "0";
                //store current time
                long curTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                //Call the controller to find the character to be displayed
                val = c.returnTime(curTime, Convert.ToInt32(this.zero.Tag), this.insertext.Text);
                //to display the character
                this.insertext.Text = val;
            }
            else
            {
                string[] tempword; //to store words
                //store each word in the sentence separated by space
                tempword = this.insertext.Text.Split(' ');
                string final = "";

                //tempdata = tempword[tempword.Length - 1];
                for (int i = 0; i < (tempword.Length - 1); i++)
                {
                    final = tempword[i] + " ";
                }


                //to print the predicted words depending on the click count
                if (count == 0 && result.Count >= 1)
                {
                    this.insertext.Text = final + result[0];
                    count++;
                }
                else if (count == 1 && result.Count >= 2)
                {
                    this.insertext.Text = final + result[1];
                    count++;
                }
                else if (count == 2 && result.Count >= 3)
                {
                    this.insertext.Text = final + result[2];
                    count++;
                }
                else if (count == 3 && result.Count >= 4)
                {
                    this.insertext.Text = final + result[3];
                    count++;
                }
                else if (count == 4 && result.Count >= 5)
                {
                    this.insertext.Text = final + result[4];
                    count++;
                }
                else if (count == 5 && result.Count >= 6)
                {
                    this.insertext.Text = final + result[5];
                    count++;
                }
                else if (count == 6 && result.Count >= 7)
                {
                    this.insertext.Text = final + result[6];
                    count++;
                }
                else if (count == 7 && result.Count >= 8)
                {
                    this.insertext.Text = final + result[7];
                    count++;
                    count = 0;
                }
            }
        }

        /// <summary>
        /// Function for handling the  button clicks on button #
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void Button_ClickSpace(object sender, RoutedEventArgs e)
        {
            //insert a space between words
            this.insertext.Text = this.insertext.Text + " ";
            _key = "";
        }

        /// <summary>
        /// for the text display
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// For the predictive or not checkbox
        /// </summary>
        /// <param name="sender">the caller for function</param>
        /// <param name="e">Sender for the function</param>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}

