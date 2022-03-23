//Base code project for CMP1903M Assessment 1
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Program
    {
        static void Main()
        {

            //Create 'Input' object
            Input inputManager = new Input();

            //Get either manually entered text, or text from a file.
            //Depending on answer picked by user
            int choice = inputManager.optionsInput();
            string text = "";
            if (choice == 1)
            {
                //keyboard
                text = inputManager.manualTextInput();
            }
            else if (choice == 2)
            {
                // read text from file
                text = inputManager.fileTextInput();                    
            }

            //Create an 'Analyse' object
            Analyse analyseManager = new Analyse();

            //Pass the text input to the 'analyseText' method
            //Receive a list of integers back

            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();
            parameters = analyseManager.analyseText(text);

            //List of FrequencyPairs to hold the frequencies of each character in the string
            List<FrequencyPair> pairs = new List<FrequencyPair>();
            pairs = analyseManager.analyseFrequency(text);           

            //Report the results of the analysis
            Report reportManager = new Report();
            reportManager.outputConsole(parameters);
            reportManager.outputConsole(pairs);

            // if the choice was 2 then produce a long words file as well
            if (choice == 2)
            {
                List<String> longWords = analyseManager.analyseLongWords(text, 7);
                string path = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "longWords.txt";
                reportManager.outputFile(fileName, longWords);
            }

        }



    }
}
