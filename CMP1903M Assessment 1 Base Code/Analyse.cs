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

            //1. Number of sentences
            // remove punctuation            
            var result = stripPunc(text);
            string noPuncText = result.Item1;
            // second value returned is the number of sentences (refer method)
            values[0] = result.Item2;

            // remove whitespaces
            string strippedText = removeWhite(noPuncText); // strippedText now contains only letters

            //2. Number of vowels
            // string of vowels
            string vowels = "aeiou";
            // count the total occurences of each vowel using the function
            int numVowels = countOccurences(vowels, strippedText);
            values[1] = numVowels;

            //3. Number of consonants
            // consonants are every letter that isn't a vowel therefore
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

            // sort the characters into descending order based on their frequency in the text
            var charFrequencies = from c in text.ToArray()                                  
                                  group c by c into groupFrequencies
                                  orderby groupFrequencies.Count() descending
                                  select groupFrequencies;

            // loop through these character frequencies and append them as frequency pairs to the pairs list
            foreach (var c in charFrequencies)
            {
                FrequencyPair pair = new FrequencyPair(c.Key.ToString(), c.Count());
                pairs.Add(pair);
            }
            return pairs;
        }

        //Method: analyseLongWords
        //Arguments: string, int
        //Returns: list of strings
        //Returns a list of strings that are above the minimum length parameter
        public List<string> analyseLongWords(string text, int minCharacters)
        {
            // remove punctuation so the text can be split using white spaces
            var result = stripPunc(text);
            text = result.Item1;
            // split the text into a list of words
            string[] words = text.Split(" ");

            // add any words that are equal in length or longer than the minCharacters to a list of longWords and then return them
            List<string> longWords = new List<string>();
            foreach (string word in words)
            {
                if (word.Length >= minCharacters)
                {
                    longWords.Add(word);
                }
            }
            return longWords;
        }


        //Method: stripPunc
        //Arguments: string
        //Returns: tuple<string, int>
        //returns a stripped copy of the original string and the amount of sentences
        //the copy will only contain alphabetical characters and whitespaces
        private Tuple<string, int> stripPunc(string text)
        {
            int sentences = 0;
            var stringBuilder = new StringBuilder();
            // use a bool to ensure proper counting of sentences
            // if multiple punctuation in a row the number of sentences should only increase by one.
            // i.e ... = 1 and !?!? = 1
            bool firstPunc = false;  

            // loop through each character and check if it is punctuation, if it isn't add to the stripped text
            // else check if its the end of a sentence, if so increase the sentence count
            foreach(char c in text)
            {
                if (char.IsLetter(c) || c == ' ')  
                {
                    // add the character since it is a letter / space
                    stringBuilder.Append(c);
                    firstPunc = true;
                }
                else if((c == '.' || c == '?' || c == '!') && firstPunc) //firstPunc used to check it isn't just repeated punctuation
                { 
                    // since the character marks the end of a sentence increment by one and rest the firstPunc flag to false
                    sentences++;                    
                    stringBuilder.Append(' '); // ensure gap between words is kept by adding a space
                    firstPunc = false;
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
            // Loop through each character and add any that are not a space to a new string and return it
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
            // loop through each letter in the stringOfLetters and count occurences
            foreach(char letter in stringOfLetters)
            {
                // append the individual count returned to the total count for all the letters
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
            // convert both strings to lowercase
            letter = char.ToLower(letter);
            text = text.ToLower();
            // loop through each characterin the text and compare with the letter
            // return the total number of occurences of the letter
            foreach (char c in text)
            {
                // if the letter matches the character increase the count
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
            // the parameter upper refers to whetehr uppercase should be counted
            // if true upper is counted
            // else lower is counted

            int count = 0;
            // loop through each character in the text and return the total count of the desired case
            foreach(char c in text)
            {
                // if the character is uppercase and upper is being counted increment count
                if (char.IsUpper(c) && upper)
                {
                    count++;
                }
                // if the character is lowercase and lower is being counted increment count
                else if (char.IsLower(c) && !upper)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
