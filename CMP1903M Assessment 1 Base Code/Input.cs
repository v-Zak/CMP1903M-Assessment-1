using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class Input
    {
        //Handles All User Input


        //Method: optionsInput
        //Arguments: none
        //Returns: integer
        //Asks user whether they want to enter text via the keyboard or from a file
        public int optionsInput()
        {
            // print out the allowed options and wait for input
            Console.WriteLine("1. Do you want to enter the text via the keyboard?");
            Console.WriteLine("2. Do you want to read in the text from a file?");
            Console.WriteLine("Enter your choice (1 or 2): ");
            string? ansText = Console.ReadLine();
            // test to see if the input is valid before returning it            
            try
            {
                // first try convert it to a integer
                int ans = Convert.ToInt32(ansText);
                // then check if the value is within the allowed range, if so return
                if (ans < 3 && ans > 0) 
                { 
                    return ans;
                }
                else
                {
                    // print out the error they made and recursively call the function until a valid input is reached
                    Console.WriteLine($"Option must be 1 or 2. Try again.");
                    return optionsInput();
                }

                
            }
            // print out the error they made and recursively call the function until a valid input is reached
            catch (FormatException)
            {
                Console.WriteLine($"The option entered, {ansText}, is not a valid number. Try again.");
                return optionsInput();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                return optionsInput();
            }
        }
        
        //Method: manualTextInput
        //Arguments: none
        //Returns: string
        //Gets text input from the keyboard
        public string manualTextInput()
        {
            // tell the user to enter the text
            string text = "";
            Console.WriteLine("Enter the text to be analysed, ending it with an *. ");
            // repeatedly ask for input until the escape character is entered
            while (!text.Contains('*'))
            {
                text = text + Console.ReadLine();
            }
            // splice the text so it contains only the text before the escape character (*)
            // then return the text
            int escapeIndex = text.IndexOf('*');
            text = text.Remove(escapeIndex);
            return text;
        }

        //Method: fileTextInput
        //Arguments: string (the file path)
        //Returns: string
        //Gets text input from a .txt file
        public string fileTextInput()
        {
            // Ask the user to enter the full file path
            // if nothing is entered then use the test file path

            Console.WriteLine("Enter the full file path or press enter to use the test file: ");
            string? path = Console.ReadLine();
            if (String.IsNullOrEmpty(path))
            {
                Console.WriteLine("No path was entered so the test file will be used");
                // get the test file ensuring the file exists
                try
                {
                    path = getTestPath();
                }
                catch (TestFileNotFoundException)
                {
                    // the test file couldn't be found so recall function
                    Console.WriteLine("Error: The test file could not be found. Use a different file");
                    return fileTextInput();
                }

                
                Console.WriteLine(path);
            }

            try
            {
                // attempt to find the file from the path specified
                // catch any errors found and recursively call the function until a valid file is read
                string text = File.ReadAllText(path);
                // return text from file. if file contains an escape character (*) return only the text before the first instance of the character
                if (text.Contains('*')){
                    Console.WriteLine("File contained an escape character (*). So only text before this character will be examined.\n");
                    int escapeIndex = text.IndexOf('*');
                    text = text.Remove(escapeIndex);
                }
                // print out the text found to the command line so the user can see what will be analysed
                Console.WriteLine("The input text is as follows:\n");
                Console.WriteLine(text);
                Console.WriteLine(); // leave one line blank
                return text;
            }
            catch (FileNotFoundException)
            {
                // Path to the file was invalid so recall function
                Console.WriteLine($"The file can't be found, {path} , try again.");
                return fileTextInput();
            }
            catch (Exception exception)
            {
                // Unexpected error occured so print out the error message
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                return fileTextInput();
            }

            
        }

        //Method: getTestPath
        //Arguments: none
        //Returns: string
        //Gets the path of the test file and returns it
        public string getTestPath()
        {
            // Get the path to the current excecutable
            string path = AppDomain.CurrentDomain.BaseDirectory;
            // Base Directory fetches the below path
            //  ....\CMP1903M Assessment 1 Base Code\CMP1903M Assessment 1 Base Code\bin\Debug\net6.0\
            // remove the end of the path and replace with the test file location
            path = path.Split(@"\CMP1903M Assessment 1 Base Code\bin")[0];
            string end = @"\IO Folder\test.txt";
            path = path + end;
            // check the path is valid before returning
            if (File.Exists(path))
            {
                return path;
            }
            else
            {
                throw new TestFileNotFoundException();
            }            
        }
    }
}
