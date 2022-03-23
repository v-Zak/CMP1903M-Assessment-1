using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Analyse
    {
        //Handles the analysis of text

        //Method: analyseText
        //Arguments: string
        //Returns: list of integers
        //Calculates and returns an analysis of the text
        public List<int> analyseText(string text)
        {
            //List of integers to hold the first five measurements:
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }

            //1. Number of sentences and remove punctuation            
            var result = stripPunc(text);
            string noPuncText = result.Item1;
            values[0] = result.Item2;

            // remove whitespaces
            string strippedText = removeWhite(noPuncText);

            //2. Number of vowels
            string vowels = "aeiou";
            int numVowels = countOccurences(vowels, strippedText);
            values[1] = numVowels;

            //3. Number of consonants
            // consonants are every letter that isn't a vowel
            // find consonants by subtracting the vowels from the total characters
            int numCharacters = strippedText.Length;
            int consonants = numCharacters - numVowels;
            values[2] = consonants;

            //4. Number of upper case letters
            values [3] = countCase(true, strippedText);

            //5. Number of lower case letters
            values[4] = countCase(false, strippedText);

            return values;
        }
        public List<FrequencyPair> analyseFrequency(string text)
        {
            // strip the text into alphabetical characters only and convert to lower case
            var result = stripPunc(text);
            text = result.Item1;
            text = removeWhite(text);
            text = text.ToLower();

            List<FrequencyPair> pairs = new List<FrequencyPair>();

            var charFrequencies = from c in text.ToArray()                                  
                                  group c by c into groupFrequencies
                                  orderby groupFrequencies.Count() descending
                                  select groupFrequencies;

            foreach (var c in charFrequencies)
            {
                FrequencyPair pair = new FrequencyPair(c.Key.ToString(), c.Count());
                pairs.Add(pair);
            }
            return pairs;
        }


        //Method: stripPunc
        //Arguments: string
        //Returns: string
        //returns a stripped copy of the original string and the amount of sentences
        //the copy will only contain alphanumerical characters and whitespaces
        private Tuple<string, int> stripPunc(string text)
        {
            int sentences = 0;
            var stringBuilder = new StringBuilder();
            // use a bool to ensure proper counting of sentences
            // if multiple punctuation in a row the number of sentences should only increase by one.
            // i.e ... = 1 and !?!? = 1
            bool lastPunc = false;  

            // loop through each character and check if it is punctuation, if it isn't add to the stripped text
            // else check if its the end of a sentence, if so increase the sentence count
            foreach(char c in text)
            {
                if (char.IsLetter(c) || c == ' ')  
                {
                    stringBuilder.Append(c);
                    lastPunc = false;
                }
                else if((c == '.' || c == '?' || c == '!') && !lastPunc)
                {
                   
                    sentences++;
                    lastPunc = true;
                }
            }
            return new Tuple<string, int> (stringBuilder.ToString(), sentences);
        }

        //Method: removeWhite
        //Arguments: string
        //Returns: string
        //returns a string of characters excluding any spaces
        private string removeWhite(string text)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in text)
            {
                if (!(c == ' '))
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }

        //Method: countOccurences
        //Arguments: string, string
        //Returns: int
        //returns the total occurences of all the individual letters in stringofLetters in the text
        private int countOccurences(string stringOfLetters, string text)
        {
            int count = 0;
            foreach(char letter in stringOfLetters)
            {
                count += countOccurences(letter, text);
            }

            return count;
        }

        //Method: countOccurences
        //Arguments: char, string
        //Returns: int
        //returns the total occurences of the letter in the text
        private int countOccurences(char letter, string text)
        {
            int count = 0;
            letter = char.ToLower(letter);
            text = text.ToLower();
            foreach(char c in text)
            {
                if (c == letter)
                {
                    count++;
                }
            }
            return count;
        }

        //Method: countCase
        //Arguments: bool, string
        //Returns: int
        //returns the total occurences of the specified case.
        // if upper is true uppercase is counted, if false then lowercase is counted.
        private int countCase(bool upper, string text)
        {
            int count = 0;
            foreach(char c in text)
            {
                if (char.IsUpper(c) && upper)
                {
                    count++;
                }
                else if(char.IsLower(c) && !upper)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
