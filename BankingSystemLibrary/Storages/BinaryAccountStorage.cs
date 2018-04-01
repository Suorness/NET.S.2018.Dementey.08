namespace BankingSystemLibrary.Storages
{
    using System.Collections.Generic;
    using System.IO;
    using BankingSystemLibrary.Models;
    using BankingSystemLibrary.Services.AccountFactory;

    public class BinaryAccountStorage : IAccountStorage
    {
        private readonly string _filePath;
        private readonly IAccountManager _accountManager;

        public BinaryAccountStorage(string filePath, IAccountManager accountManager)
        {
            _filePath = filePath ?? throw new System.ArgumentNullException(nameof(filePath));
            _accountManager = accountManager ?? throw new System.ArgumentNullException(nameof(accountManager));
        }

        public void AddAccount(BankAccount account)
        {
            using (FileStream fs = File.Open(_filePath, FileMode.Append))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                WriteAccount(account, writer);
            }
        }

        public IEnumerable<BankAccount> GetBankAccounts()
        {
            var accounts = new List<BankAccount>();
            using (FileStream fs = File.Open(_filePath, FileMode.OpenOrCreate))
            using (BinaryReader reader = new BinaryReader(fs))
            {
                while (reader.PeekChar() > -1)
                {
                    accounts.Add(ReadAccount(reader));
                }
            }

            return accounts;
        }

        public void RemoveAccount(BankAccount account)
        {
            var accounts = new List<BankAccount>(GetBankAccounts());
            accounts.Remove(FindAccount(account, accounts));
            SetBanksAccount(accounts);
        }

        public void SetBanksAccount(IEnumerable<BankAccount> accounts)
        {
            using (FileStream fs = File.Open(_filePath, FileMode.Create))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                foreach (var account in accounts)
                {
                    WriteAccount(account, writer);
                }
            }
        }

        public void UpdateAccount(BankAccount account)
        {
            var accounts = new List<BankAccount>(GetBankAccounts());

            accounts.Remove(FindAccount(account, accounts));
            accounts.Add(account);

            SetBanksAccount(accounts);
        }

        private void WriteAccount(BankAccount account, BinaryWriter writer)
        {
            writer.Write(account.Number);
            writer.Write((int)account.Type);
            writer.Write(account.FirstName);
            writer.Write(account.LastName);
            writer.Write(account.Balance);
            writer.Write(account.Bonus);
        }

        private BankAccount ReadAccount(BinaryReader reader)
        {
            string number = reader.ReadString();
            AccountType type = (AccountType)reader.ReadInt32();
            string firstName = reader.ReadString();
            string lastName = reader.ReadString();
            decimal balance = reader.ReadDecimal();
            int bonus = reader.ReadInt32();
            return _accountManager.CreateAccount(type, number, lastName, firstName, balance, bonus);
        }

        private BankAccount FindAccount(BankAccount account, IEnumerable<BankAccount> accounts)
        {
            BankAccount resultAccount = null;

            foreach (var acc in accounts)
            {
                if (acc.Number == account.Number)
                {
                    resultAccount = acc;
                }
            }

            if (ReferenceEquals(resultAccount, null))
            {
                throw new StorageException("An error occurred while searching for an account.");
            }

            return resultAccount;
        }
    }
}
