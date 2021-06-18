using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace GuessTheWord
{
    public delegate void CheckLetter(string letter);
    
    public partial class Form1 : Form
    {
        const int  MAX_NUMBER_OF_CHANCE = 5;
        //An event that is invoked everytime when any letter is guessed
        event CheckLetter ChkLtr;

        string input;
        string missedLetters = "";
        
        //A word which is to find
        string wordToFind= "";
        
        //Current status of the found letters in the word
        string wordToDisplay = "";
        
        //Character array of word
        char[] wordToFindArray;
        int[] wordToFindLettersPosition;
        bool IsLetterFound = false;

        //Random number generator class to get word randomly from the word list
        Random rndm = new Random(0);
        
        //Collection of word
        List<string> wordList = new List<string>();
        
        // A list of index positions to keep track which word is already played
        List<int> wordsIndexAlreadyPlayed = new List<int>();

        int missedLetterCount = 0;

        public Form1()
        {
            InitializeComponent();

            //Subscribe the event
            this.ChkLtr += new CheckLetter(Form1_ChkLtr);
            
            //Create a word list
            CreateWordList();

            //Start a new game
            RestartTheGame();
        }

        private void CreateWordList()
        {
            // A hardcoded word list with 15 words
            wordList.Add("Location");
            wordList.Add("Invocation");
            wordList.Add("Education");
            wordList.Add("Country");
            wordList.Add("National");
            wordList.Add("Computer");
            wordList.Add("Calculator");
            wordList.Add("Transmission");
            wordList.Add("Continental");
            wordList.Add("Fashionable");
            wordList.Add("Operation");
            wordList.Add("Seasonal");
            wordList.Add("Tomorrow");
            wordList.Add("Yesterday");
            wordList.Add("Perfume");
        }

        private string GetNewWordFromPool()
        {
            bool IsNewWord = false;
            //Default word
            string temp = "HANGMAN";
            
            try
            {
                while (IsNewWord == false)
                {
                    //-------------To get word randomly from words pool ------------
                    int index = rndm.Next();

                    //To plot the number in our WordList range
                    index = index % wordList.Count;

                    //----------- But Not taking repeated word --------------------

                    //Here I used lambda expression to check whether word is already played or not
                    if (!wordsIndexAlreadyPlayed.Exists(e => e == index))
                    {
                        temp = wordList[index];
                        wordsIndexAlreadyPlayed.Add(index);
                        IsNewWord = true;
                        break;
                    }
                    else
                    {
                        IsNewWord = false;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            return temp.ToUpper();
        }

        private void RestartTheGame()
        {
            try
            {
                wordToFind = GetNewWordFromPool();
                wordToFind = wordToFind.ToUpper();
                wordToFindArray = wordToFind.ToCharArray();

                wordToFindLettersPosition = new int[wordToFind.Length];

                //Resetting other counters and variables
                input = "";
                wordToDisplay = "";
                for (int i = 0; i < wordToFind.Length; i++)
                {
                    wordToDisplay += "-";
                }

                missedLetters = "";
                missedLetterCount = 0;

                label_Word.Text = wordToDisplay.ToUpper();
                label_MissedLetters.Text = missedLetters;
                label_MissedLtrCnt.Text = MAX_NUMBER_OF_CHANCE.ToString();
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        //Event handler
        private void Form1_ChkLtr(string currentInputletter)
        {
            try
            {
                if (missedLetterCount < MAX_NUMBER_OF_CHANCE)
                {

                    IsLetterFound = false;
                    for (int i = 0; i < wordToFindArray.Length; i++)
                    {
                        if (currentInputletter[0] == wordToFindArray[i])
                        {
                            wordToFindLettersPosition[i] = 1;
                            IsLetterFound = true;
                        }
                    }

                    if (IsLetterFound == false)
                    {
                        missedLetters += currentInputletter + ", ";
                        missedLetterCount++;
                        label_MissedLtrCnt.Text = (MAX_NUMBER_OF_CHANCE - missedLetterCount).ToString();
                    }

                    wordToDisplay = "";
                    for (int i = 0; i < wordToFindArray.Length; i++)
                    {
                        if (wordToFindLettersPosition[i] == 1)
                        {
                            wordToDisplay += wordToFindArray[i].ToString();
                        }
                        else
                        {
                            wordToDisplay += "-";
                        }
                    }

                    label_Word.Text = wordToDisplay.ToUpper();
                    label_MissedLetters.Text = missedLetters;

                    if (wordToFindLettersPosition.All(e => e == 1))
                    {
                        MessageBox.Show("CONGRATS! YOU GOT THE WORD.", "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RestartTheGame();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, you lost the game" + "\nThe correct word was: " + wordToFind, "RESULT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RestartTheGame();
                }
                Application.DoEvents();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        #region Getting Alphabets
        
        private void button_A_Click(object sender, EventArgs e)
        {
            input = "A"; 
            
            ChkLtr(input);
        }

        private void button_B_Click(object sender, EventArgs e)
        {
            input = "B";
            
            ChkLtr(input);
        }

        private void button_C_Click(object sender, EventArgs e)
        {
            input = "C";
            
            ChkLtr(input);
        }

        private void button_D_Click(object sender, EventArgs e)
        {
            input = "D";
            
            ChkLtr(input);
        }

        private void button_E_Click(object sender, EventArgs e)
        {
            input = "E";
            
            ChkLtr(input);
        }

        private void button_F_Click(object sender, EventArgs e)
        {
            input = "F";
            
            ChkLtr(input);
        }

        private void button_G_Click(object sender, EventArgs e)
        {
            input = "G";
            
            ChkLtr(input);
        }

        private void button_H_Click(object sender, EventArgs e)
        {
            input = "H";
            
            ChkLtr(input);
        }

        private void button_I_Click(object sender, EventArgs e)
        {
            input = "I";
            
            ChkLtr(input);
        }

        private void button_J_Click(object sender, EventArgs e)
        {
            input = "J";
            
            ChkLtr(input);
        }

        private void button_K_Click(object sender, EventArgs e)
        {
            input = "K";
            
            ChkLtr(input);
        }

        private void button_L_Click(object sender, EventArgs e)
        {
            input = "L";
            
            ChkLtr(input);
        }

        private void button_M_Click(object sender, EventArgs e)
        {
            input = "M";
            
            ChkLtr(input);
        }

        private void button_N_Click(object sender, EventArgs e)
        {
            input = "N";
            
            ChkLtr(input);
        }

        private void button_O_Click(object sender, EventArgs e)
        {
            input = "O";
            
            ChkLtr(input);
        }

        private void button_P_Click(object sender, EventArgs e)
        {
            input = "P";
            
            ChkLtr(input);
        }

        private void button_Q_Click(object sender, EventArgs e)
        {
            input = "Q";
            
            ChkLtr(input);
        }

        private void button_R_Click(object sender, EventArgs e)
        {
            input = "R";
            
            ChkLtr(input);
        }

        private void button_S_Click(object sender, EventArgs e)
        {
            input = "S";
            
            ChkLtr(input);
        }

        private void button_T_Click(object sender, EventArgs e)
        {
            input = "T";
            
            ChkLtr(input);
        }

        private void button_U_Click(object sender, EventArgs e)
        {
            input = "U";
            
            ChkLtr(input);
        }

        private void button_V_Click(object sender, EventArgs e)
        {
            input = "V";
            
            ChkLtr(input);
        }

        private void button_W_Click(object sender, EventArgs e)
        {
            input = "W";
            
            ChkLtr(input);
        }

        private void button_X_Click(object sender, EventArgs e)
        {
            input = "X";
            
            ChkLtr(input);
        }

        private void button_Y_Click(object sender, EventArgs e)
        {
            input = "Y";
            
            ChkLtr(input);
        }

        private void button_Z_Click(object sender, EventArgs e)
        {
            input = "Z";
            
            ChkLtr(input);
        }
#endregion

        private void button_LoadNewWord_Click(object sender, EventArgs e)
        {
            RestartTheGame();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                e.Link.LinkData = "http://hemant-srivastava.blogspot.com/";
                System.Diagnostics.Process.Start(e.Link.LinkData.ToString());
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
