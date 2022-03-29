using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class FrequencyPair
    {
        // class used to store a string and its associated frequency

        // private sets so can't be changed externally but the values can still be viewed
        public string value { get; private set; }

        public int frequency { get; private set; }

        public FrequencyPair(string value, int frequency)
        {
            this.value = value;
            this.frequency = frequency;
        }


        //simple ToString overide method
        //Method: ToString
        //Arguments: none
        //Returns: string
        //returns a formatted version of the data contained in the class
        public override string ToString()
        {
            return $"Letter: {value} - Frequency: {frequency}";
        }
    }
}
