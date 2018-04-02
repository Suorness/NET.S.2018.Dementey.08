namespace Storage
{   
    using System.Collections.Generic;
    using System.IO;
    using Models;
    using Storage.Exceptions;

    public class BinaryAccountStorage : IAccountStorage
    {
        private readonly string _filePath;

        public BinaryAccountStorage(string filePath)
        {
            _filePath = filePath ?? throw new System.ArgumentNullException(nameof(filePath));
        }

        public void AddAccount(AccountDal account)
        {
            using (FileStream fs = File.Open(_filePath, FileMode.Append))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                WriteAccount(account, writer);
            }
        }

        public IEnumerable<AccountDal> GetBankAccounts()
        {
            var accounts = new List<AccountDal>();
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

        public void RemoveAccount(AccountDal account)
        {
            var accounts = new List<AccountDal>(GetBankAccounts());
            accounts.Remove(FindAccount(account, accounts));
            SetBankAccounts(accounts);
        }

        public void SetBankAccounts(IEnumerable<AccountDal> accounts)
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

        public void UpdateAccount(AccountDal account)
        {
            var accounts = new List<AccountDal>(GetBankAccounts());

            accounts.Remove(FindAccount(account, accounts));
            accounts.Add(account);

            SetBankAccounts(accounts);
        }

        private void WriteAccount(AccountDal account, BinaryWriter writer)
        {
            writer.Write(account.Number);
            writer.Write((int)account.Type);
            writer.Write(account.FirstName);
            writer.Write(account.LastName);
            writer.Write(account.Balance);
            writer.Write(account.Bonus);
        }

        private AccountDal ReadAccount(BinaryReader reader)
        {
            string number = reader.ReadString();
            AccountType type = (AccountType)reader.ReadInt32();
            string firstName = reader.ReadString();
            string lastName = reader.ReadString();
            decimal balance = reader.ReadDecimal();
            int bonus = reader.ReadInt32();
            return new AccountDal
            {
                Type = type,
                FirstName = firstName,
                LastName = lastName,
                Balance = balance,
                Bonus = bonus,
                Number = number
            };
        }

        private AccountDal FindAccount(AccountDal account, IEnumerable<AccountDal> accounts)
        {
            AccountDal resultAccount = null;

            foreach (var acc in accounts)
            {
                if (acc.Number == account.Number)
                {
                    resultAccount = acc;
                }
            }

            if (ReferenceEquals(resultAccount, null))
            {
                throw new AccountNotFoundException("An error occurred while searching for an account.");
            }

            return resultAccount;
        }
    }
}
