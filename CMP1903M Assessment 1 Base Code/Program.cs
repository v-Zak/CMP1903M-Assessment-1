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
            //Local list of integers to hold the first five measurements of the text
            List<int> parameters = new List<int>();

            //Create 'Input' object
            //Get either manually entered text, or text from a file
            Input inputManager = new Input();

            while (true)
            {
                string text = inputManager.fileTextInput();
                Console.WriteLine(text);
            }
            
                int choice = inputManager.optionsInput();
                if (choice == 1)
                {
                //keyboard
                    string text = inputManager.manualTextInput();
                }
                else if (choice == 2)
                {
                    // read text from file
                    string text = inputManager.fileTextInput();                    
                }
            


            //Create an 'Analyse' object
            //Pass the text input to the 'analyseText' method


            //Receive a list of integers back


            //Report the results of the analysis


            //TO ADD: Get the frequency of individual letters?

           
        }
        
        
    
    }
}
