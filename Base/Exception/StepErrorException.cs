using System;

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
