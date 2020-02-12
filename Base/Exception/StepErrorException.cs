using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCoypuAppiumFramework.Base.Exception
{
    public class StepErrorException : System.Exception
    {
        public StepErrorException() : base()
        {
        }
        public StepErrorException(String message) : base(message)
        {
        }
        public StepErrorException(string message, System.Exception inner)
        : base(message, inner)
        {
        }
    }
}
