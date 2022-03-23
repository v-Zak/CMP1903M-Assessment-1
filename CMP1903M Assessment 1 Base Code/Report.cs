using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    class Report
    {
        //Handles the reporting of the analysis


        //Method: outputConsole
        //Arguments: list of integers
        //Returns: None
        //prints to the console the formatted list of parameters
        public void outputConsole(List<int> output)
        {
            Console.WriteLine("See below the basic analysis of the text:");
            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine(output[i]);
            }
            Console.WriteLine(); // leave one line blank   
        }

        //Method: outputConsole
        //Arguments: list of FrequencPairs
        //Returns: None
        //prints to the console the formatted list of pairs
        public void outputConsole(List<FrequencyPair> output)
        {
            Console.WriteLine("See below the sorted values from most frequent to least frequent:");
            for (int i = 0; i < output.Count; i++)
            {
                Console.WriteLine(output[i].ToString());
            }
            Console.WriteLine(); // leave one line blank
        }

        //Method: outputFile
        //Arguments: list of words
        //Returns: None
        //outputs the words to a new file line by line
        public void outputFile(string fileName,List<string> output)
        {
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                // Base Directory fetches the below path
                //  ....\CMP1903M Assessment 1 Base Code\CMP1903M Assessment 1 Base Code\bin\Debug\net6.0\
                // remove the end of the path and replace with the test file location
                path = path.Split(@"\CMP1903M Assessment 1 Base Code\bin")[0];
                string end = @"\IO Folder\" + fileName;
                path = path + end;

                // use the path to output the list of words and tell the user where it is
                File.WriteAllLines(fileName, output);
                Console.WriteLine("A file of long words has successfully been created");
                Console.WriteLine($"The path is: {path}");
            }     
            catch (Exception exception)
            {
                // Unexpexted error occured so print out the error message
                Console.WriteLine("The long words file creation was unsuccessful");
                Console.WriteLine($"Unexpected error:  { exception.Message }");

            }
        }

    }
}
