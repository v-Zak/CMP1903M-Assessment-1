﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class FrequencyPair
    {
        // used to store a string and its associated frequency
        public string value { get; set; }

        public int frequency { get; set; }

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
            return $"Value: {value} - Frequency: {frequency}";
        }
    }
}