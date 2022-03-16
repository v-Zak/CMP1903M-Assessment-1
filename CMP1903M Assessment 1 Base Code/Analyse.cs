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
            List<int> values = new List<int>();
            //Initialise all the values in the list to '0'
            for (int i = 0; i < 5; i++)
            {
                values.Add(0);
            }

            //List of integers to hold the first five measurements:
            //1. Number of sentences
            // Will consider each . as a sentence even if consecutive. Need to fix.
            int sentences = text.Split('.').Length - 1;
            values[0] = sentences;

            // remove whitespaces and punctuation
            string strippedText = strip(text);
            Console.WriteLine(strippedText);

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


        //Method: stip
        //Arguments: string
        //Returns: string
        //returns a stipped copy of the original string
        //the copy will only contain alphabetical characters
        private string strip(string text)
        {
            var stringBuilder = new StringBuilder();
            foreach(char c in text)
            {
                if (char.IsLetter(c))
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
