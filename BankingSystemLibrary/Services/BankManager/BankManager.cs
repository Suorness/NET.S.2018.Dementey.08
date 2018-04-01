namespace BankingSystemLibrary.Services.BankManager
{
    using System.Collections.Generic;
    using BankingSystemLibrary.Models;
    using BankingSystemLibrary.Services.AccountFactory;
    using BankingSystemLibrary.Services.BankManager.Exceptions;
    using BankingSystemLibrary.Storages;

    public class BankManager : IBankManager
    {
        #region private fields
        private readonly IAccountManager _accountFactory;
        private readonly IAccountStorage _accountStorage;

        private List<BankAccount> _accounts = new List<BankAccount>();
        #endregion private fields

        public BankManager(IAccountManager accountFactory, IAccountStorage accountStorage)
        {
            _accountFactory = accountFactory ?? throw new System.ArgumentNullException(nameof(accountFactory));
            _accountStorage = accountStorage ?? throw new System.ArgumentNullException(nameof(accountStorage));

            try
            {
                _accounts.AddRange(_accountStorage.GetBankAccounts());
            }
            catch (StorageException e)
            {
                throw new ManagerException("There were problems reading from the repository.", e);
            }
        }

        public void CloseAccount(string number)
        {
            BankAccount account = FindAccount(number);

            account.CloseAccount();

            SaveChanges(account);
        }

        public void DepositMoney(string number, decimal amount)
        {
            BankAccount account = FindAccount(number);

            account.DepositMoney(amount);

            SaveChanges(account);
        }

        public void OpenAccount(string firstName, string lastName, decimal balance, AccountType type = AccountType.BaseAccount)
        {
            BankAccount account = _accountFactory.CreateAccount(type, GenerateNumber(), lastName, firstName, balance, 0);
            _accounts.Add(account);
            try
            {
                _accountStorage.AddAccount(account);
            }
            catch (StorageException e)
            {
                _accounts.Remove(account);
                throw new ManagerException("An error occurred while working with the repository.", e);
            }
        }

        public void WithdrawMoney(string number, decimal amount)
        {
            BankAccount account = FindAccount(number);

            account.WithdrawMoney(amount);

            SaveChanges(account);
        }

        public BankAccount GetAccount(string number)
        {
            return FindAccount(number);
        }

        public IEnumerable<BankAccount> GetAccounts()
        {
            return _accountStorage.GetBankAccounts();
        }

        private BankAccount FindAccount(string number)
        {
            if (number == null)
            {
                throw new System.ArgumentNullException(nameof(number));
            }

            BankAccount resultAccount = null;

            _accounts.Clear();
            try
            {
                _accounts.AddRange(_accountStorage.GetBankAccounts());
            }
            catch (StorageException e)
            {
                throw new ManagerException("There were problems reading from the repository.", e);
            }

            foreach (var account in _accounts)
            {
                if (account.Number == number)
                {
                    resultAccount = account;
                    break;
                }
            }

            if (ReferenceEquals(resultAccount, null))
            {
                throw new ManagerException("Account not found.");
            }

            return resultAccount;
        }

        private void SaveChanges(BankAccount account)
        {
            try
            {
                _accountStorage.UpdateAccount(account);
            }
            catch (StorageException e)
            {
                throw new ManagerException("An error occurred while working with the repository.", e);
            }
        }

        private string GenerateNumber()
        {
            return (_accounts.Count + 1).ToString();
        }
    }
}
