namespace BankingSystemLibrary.Services.AccountFactory
{
    using BankingSystemLibrary.Models;

    /// <summary>
    /// The interface describing the factory accounts.
    /// </summary>
    public interface IAccountManager
    {
        /// <summary>
        /// Creates instances of the account.
        /// </summary>
        /// <param name="type">Account Type.</param>
        /// <param name="number">Account number.</param>
        /// <param name="lastName">Last Name of account holder.</param>
        /// <param name="firstName">First Name of account holder.</param>
        /// <param name="balance">Account balance.</param>
        /// <param name="bonus">Bonus account.</param>
        /// <exception cref="ServiceFactoryException">
        /// Throws an exception when there are problems in working with the factory service.
        /// </exception>
        /// <returns>
        /// Account.
        /// </returns>
        BankAccount CreateAccount(AccountType type, string number, string lastName, string firstName, decimal balance, int bonus);
    }
}
