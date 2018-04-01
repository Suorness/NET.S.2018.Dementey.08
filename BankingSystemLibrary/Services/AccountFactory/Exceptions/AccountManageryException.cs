namespace BankingSystemLibrary.Services.Exceptions
{
    using System;

    /// <summary>
    /// The exception class is thrown when there is a problem with the factory service.
    /// </summary>
    public class AccountManagerException : Exception
    {
        public AccountManagerException()
        {
        }

        public AccountManagerException(string message) : base(message)
        {
        }

        public AccountManagerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}