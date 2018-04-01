namespace BankingSystemLibrary.Services.BankManager.Exceptions
{
    using System;

    /// <summary>
    /// The exception class is thrown when there is a problem with the manager service.
    /// </summary>
    public class ManagerException : Exception
{
    public ManagerException()
    {
    }

    public ManagerException(string message) : base(message)
    {
    }

    public ManagerException(string message, Exception inner) : base(message, inner)
    {
    }
}
}