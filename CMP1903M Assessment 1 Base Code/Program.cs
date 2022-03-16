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
            //int choice = inputManager.optionsInput();
            int choice = 2;
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

            Console.WriteLine(text);

            //Create an 'Analyse' object
            Analyse analyseManager = new Analyse();

            //Pass the text input to the 'analyseText' method
            //Receive a list of integers back

            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();
            parameters = analyseManager.analyseText(text);

            //Report the results of the analysis
            Report reportManager = new Report();
            reportManager.outputConsole(parameters);


            //TO ADD: Get the frequency of individual letters?


        }



    }
}
