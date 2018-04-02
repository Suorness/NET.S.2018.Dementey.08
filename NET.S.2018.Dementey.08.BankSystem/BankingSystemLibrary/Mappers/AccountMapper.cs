namespace BankingSystemLibrary.Mappers
{
    using Models;
    using Storage;
    using Utils;

    /// <summary>
    /// The mapping class converts data from Dal to service
    /// </summary>
    internal static class AccountMapper
    {
        /// <summary>
        /// Converts data from the storage to service data
        /// </summary>
        /// <param name="accountDal"> Data from Dal</param>
        /// <returns>
        /// Data for the service.
        /// </returns>
        public static BankAccount ToAccount(this AccountDal accountDal)
        {
            return AccountCreater.CreateAccount(accountDal.Type, accountDal.Number, accountDal.LastName, accountDal.FirstName, accountDal.Balance, accountDal.Bonus);
        }

        /// <summary>
        /// Converts data from the service to storage data
        /// </summary>
        /// <param name="account"> Data for Dal</param>
        /// <returns></returns>
        public static AccountDal ToAccountDal(this BankAccount account)
        {
            return new AccountDal()
            {
                Type = account.Type,
                Balance = account.Balance,
                Bonus = account.Bonus,
                FirstName = account.FirstName,
                LastName = account.LastName,
                Number = account.Number
            };
        }
    }
}
