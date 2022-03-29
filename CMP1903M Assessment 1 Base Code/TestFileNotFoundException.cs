using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_Assessment_1_Base_Code
{
    public class TestFileNotFoundException : Exception
    {
        // custom exception for when th e test file can not be found / opened


        // below are the 3 common constructors for the exception
        // https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
        public TestFileNotFoundException()
        {

        }
        public TestFileNotFoundException(string message) : base(message)
        {

        }
        public TestFileNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
