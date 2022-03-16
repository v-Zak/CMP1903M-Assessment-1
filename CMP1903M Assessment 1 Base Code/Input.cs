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
            Console.WriteLine("1. Do you want to enter the text via the keyboard?");
            Console.WriteLine("2. Do you want to read in the text from a file?");
            Console.WriteLine("Enter your choice (1 or 2): ");

            string? ansText = Console.ReadLine();
            try
            {
                int ans = Convert.ToInt32(ansText);
                if (ans < 3 && ans > 0) 
                { 
                    return ans;
                }
                else
                {
                    Console.WriteLine($"Option must be 1 or 2. Try again.");
                    return optionsInput();
                }

                
            }
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
            // repeatedly ask for input until the escape character is entered
            string text = "";
            Console.WriteLine("Enter the text to be analysed, ending it with an *. ");
            while (!text.Contains('*'))
            {
                text = text + Console.ReadLine();
            }
            // splice the text so it contains only the text before the escape character (*)
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
            //Console.WriteLine("Enter the full file path:");
            //string? path = Console.ReadLine();
            string? path = @"C:\Users\Zak\Uni\OOP\CMP1903M Assessment 1 Base Code\test.txt"; // test path only comment out on final release

            try
            {
                string text = File.ReadAllText(path);
                // return text from file. if file contains an escape charcter (*) return only the text before the first instance of the character
                if (text.Contains('*')){
                    Console.WriteLine("File contained an escape character (*). So only text before this character will be examined.\n");
                    int escapeIndex = text.IndexOf('*');
                    text = text.Remove(escapeIndex);
                }
                return text;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"The file can't be found, {path} , try again.");
                return fileTextInput();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Unexpected error:  { exception.Message }");
                return fileTextInput();
            }

            
        }

    }
}
