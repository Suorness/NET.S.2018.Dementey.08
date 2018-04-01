namespace BankingSystemLibrary.Services.AccountFactory
{
    using System;
    using BankingSystemLibrary.Models;
    using BankingSystemLibrary.Services.Exceptions;

    /// <summary>
    /// Implementing the account "factory".
    /// </summary>
    public class AccountManager : IAccountManager
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
        /// <exception cref="AccountManagerException">
        /// Throws an exception when there are problems in working with the factory service.
        /// </exception>
        /// <returns>
        /// Account.
        /// </returns>
        public BankAccount CreateAccount(AccountType type, string number, string lastName, string firstName, decimal balance, int bonus)
        {
            if (number == null)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            if (lastName == null)
            {
                throw new System.ArgumentNullException(nameof(lastName));
            }

            if (firstName == null)
            {
                throw new System.ArgumentNullException(nameof(firstName));
            }

            BankAccount account;
            
            switch (type)
            {
                case AccountType.BaseAccount:
                    account = new BaseAccount(number, lastName, firstName, balance, bonus);
                    break;
                case AccountType.GoldAccount:
                    account = new GoldAccount(number, lastName, firstName, balance, bonus);
                    break;
                case AccountType.PlatinumAccount:
                    account = new PlatinumAccount(number, lastName, firstName, balance, bonus);
                    break;
                default:
                    throw new AccountManagerException($"{nameof(type)}Unknown account type.");
            }

            return account;
        }
    }
}
