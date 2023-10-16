using System;
namespace Autostore.ExceptionHandling
{
    public class InvalidUserDataException : Exception
    {
        public InvalidUserDataException() : base("Invalid user data.")
        {
        }

        public InvalidUserDataException(string message) : base(message)
        {
        }
    }
}