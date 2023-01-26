using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Folio.Modules
{
    public class ParserMOD : TemplatedControl
    {
        // singleton variables
        private static ParserMOD? current;
        public static ParserMOD? Current { get => current; set => current = value; }

        public ParserMOD()
        {
            // setup
            DataContext = this;

            // setup the singleton
            if (Current == null)
            {
                Current = this;
            }
            else if (Current != this)
            {
                Current = this;
            }
        }

        public void CountWords()
        {
            // if content isn't empty, then
            if (TextBoxMOD.Current.MAINTB.Text.Length > 0 && TextBoxMOD.Current.MAINTB.Text != "")
            {
                // get the word count with a helper method
                int wordCount = ParseAndCount(TextBoxMOD.Current.MAINTB.Text);



                // format the word counter number with a helper method
                String formattedWordCount = FormatCount(wordCount);
                // set the word counter label equal to the formatted word count
                DocuToolbarMOD.Current.WORDCT.Text = formattedWordCount;

            }
            else
            {
                // msg
                FileMenuToolbarMOD.Current.FILEINFO.Text = "ERROR: Invalid Input [no text to parse]";
                FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = true;

            }
        }

        // helper methods

        public int Count(string content)
        {
            // logging msgs
            StreamWriter Log = FileLoggerMOD.Current.LogFileOpen();
            FileLoggerMOD.Current.Log(Log, "INIT>>CALL>>LoadTextAndCountWords");

            // variables
            int letterCountWord = 0;
            int letterCountTotal = 0;
            int wordCount = 0;
            int sentenceCount = 0;

            for (int i = 0; i < content.Length; i++) 
            { 
                char toCheck = content[i];

                if (toCheck == '-')
                {
                    // if its a dash
                    FileLoggerMOD.Current.Log(Log, "dash found");

                }
                else if (toCheck == '\"')
                {
                    // if its a double quote
                    FileLoggerMOD.Current.Log(Log, "double quote found");
                }
                else if (toCheck == '\'')
                {
                    // if its a single quote
                    FileLoggerMOD.Current.Log(Log, "single quote found");
                }
                else if (toCheck is '.' or '!' or '?' or ':' or ';')
                {
                    // if its punctuation
                    FileLoggerMOD.Current.Log(Log, "punctuation found");
                }
                else if (toCheck == ',')
                {
                    // if its a common
                    FileLoggerMOD.Current.Log(Log, "comma found");
                }
                else if (toCheck != ' ')
                {
                    // if its a character
                    FileLoggerMOD.Current.Log(Log, "char found: " + toCheck);
                }
            }

            // final messages
            FileLoggerMOD.Current.Log(Log, "DNIT>>CALL>>LoadTextAndCountWords");
            FileLoggerMOD.Current.Log(Log, "OUT>>VAR>>wordCount: " + wordCount);

            // final cleanup
            Log.Close();

            return wordCount;

        }

        public int ParseAndCount(string content)
        {
            // logging msgs
            StreamWriter Log = FileLoggerMOD.Current.LogFileOpen();
            FileLoggerMOD.Current.Log(Log, "INIT>>CALL>>LoadTextAndCountWords");

            // variables
            int wordCount = 0;
            int letterCount = 0;
            string text = content;

            FileLoggerMOD.Current.Log(Log, text);

            // while the string is greater then 0,
            // loop thru and remove substrings by
            // word, increment count, until no more
            // words remain in the string
            while (text.Length > 0)
            {
                // iterate over the string
                for (int j = 0; j < text.Length; j++)
                {
                    // variable
                    char charToCheck = text[j];

                    // check the char
                    if (charToCheck == '-')
                    {
                        // if the charToCheck is a dash

                        if (letterCount > 0) 
                        {
                            // and the dash starts a string
                            FileLoggerMOD.Current.Log(Log, "//terminating em dash found");
                            // increase word count
                            wordCount++;
                            // remove the word from the string
                            text = text.Remove(0, letterCount);
                            // remove the succeeding punctuation mark
                            text = text.Remove(0, 1);
                            // reset letter count
                            letterCount = 0;
                            // msg
                            FileLoggerMOD.Current.Log(Log, text);
                            // break the loop
                            break;
                        }
                        else 
                        {
                            // else its a terminating dash
                            FileLoggerMOD.Current.Log(Log, "//floating em dash found");
                            // remove the em dash
                            text = text.Remove(0, 2);
                            // reset letter count
                            letterCount = 0;
                            // msg
                            FileLoggerMOD.Current.Log(Log, text);
                            break;
                        }
                    }
                    else if (charToCheck == '\"')
                    {
                        // else if the char is a double quote

                        if (letterCount == 0)
                        {
                            // and its by its self
                            FileLoggerMOD.Current.Log(Log, "//lone double quote found");
                            // remove the punctuation mark
                            text = text.Remove(0, 1);
                            // msg
                            FileLoggerMOD.Current.Log(Log, text);
                            // break the loop
                            break;
                        }
                        else
                        {
                            // else if its terminating a word
                            FileLoggerMOD.Current.Log(Log, "//terminating double quote found");
                            // increase word count
                            wordCount++;
                            // remove the word from the string
                            text = text.Remove(0, letterCount);
                            // remove the succeeding space
                            text = text.Remove(0, 1);
                            // reset letter count
                            letterCount = 0;
                            // msg
                            FileLoggerMOD.Current.Log(Log, text);
                            // break the loop
                            break;

                        }
                    }
                    else if (charToCheck == ' ')
                    {
                        // else if the char
                        // is a space

                        if (letterCount == 0)
                        {
                            FileLoggerMOD.Current.Log(Log, "//lone space found");
                            // and its by its self
                            // remove the single space
                            text = text.Remove(0, 1);
                            // msg
                            FileLoggerMOD.Current.Log(Log, text);
                            // break the loop
                            break;
                        }
                        else
                        {
                            // else if its terminating a word
                            FileLoggerMOD.Current.Log(Log, "//terminating space found");
                            // increase word count
                            wordCount++;
                            // remove the word from the string
                            text = text.Remove(0, letterCount);
                            // remove the succeeding space
                            text = text.Remove(0, 1);
                            // reset letter count
                            letterCount = 0;
                            // msg
                            FileLoggerMOD.Current.Log(Log, text);
                            // break the loop
                            break;
                        }
                    }
                    else if (charToCheck is '.' or ',' or '!' or '?' or ':' or ';')
                    {
                        // else if the char is
                        // a punctuation mark
                        FileLoggerMOD.Current.Log(Log, "//punctuation mark found [" + charToCheck + "]");

                        // increase word count
                        wordCount++;
                        // remove the word from the string
                        text = text.Remove(0, letterCount);
                        // remove the succeeding space
                        text = text.Remove(0, 1);
                        // reset letter count
                        letterCount = 0;
                        // msg
                        FileLoggerMOD.Current.Log(Log, text);
                        // break the loop
                        break;

                    }
                    else if (charToCheck != ' ')
                    {
                        // else if the char is
                        // not a space
                        FileLoggerMOD.Current.Log(Log, "//character found [" + charToCheck + "]");

                        // add to letterCount
                        letterCount += 1;

                        // terminating condition 1:
                        // one word string
                        // if its the last char
                        // and no space is found
                        if (j + 1 == text.Length)
                        {
                            // increase word count
                            wordCount++;
                            // remove the word from the string
                            text = text.Remove(0, letterCount);
                            // msg
                            FileLoggerMOD.Current.Log(Log, text);
                            // break the loop
                            break;
                        }

                    }
                }
            }

            // final messages
            FileLoggerMOD.Current.Log(Log, "DNIT>>CALL>>LoadTextAndCountWords");
            FileLoggerMOD.Current.Log(Log, "OUT>>VAR>>wordCount: " + wordCount);

            // final cleanup
            Log.Close();

            return wordCount;
        }

        public string FormatCount(int num)
        {

            if (num < 10)
            {
                string formattedNum = String.Format("0000{0}", num);
                return formattedNum;
            }
            else if (num < 100)
            {
                string formattedNum = String.Format("000{0}", num);
                return formattedNum;
            }
            else if (num < 1000)
            {
                string formattedNum = String.Format("00{0}", num);
                return formattedNum;
            }
            else if (num > 10000)
            {
                string formattedNum = String.Format("0{0}", num);
                return formattedNum;
            }
            else
            {
                // msgs
                FileMenuToolbarMOD.Current.FILEINFO.Text = "ERROR: Invalid Input [Number too large]";
                FileMenuToolbarMOD.Current.AlertIcon01.IsVisible = true;

                return num.ToString();
            }
        }
    }
}
