using System;
namespace Autostore.ExceptionHandling
{
    

    public class RoleAssignmentException : Exception
    {
        public RoleAssignmentException() : base("Role assignment failed.")
        {
        }

        public RoleAssignmentException(string message) : base(message)
        {
        }
    }

}
