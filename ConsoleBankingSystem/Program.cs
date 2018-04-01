namespace ConsoleBankingSystem
{
    using System;
    using System.Collections.Generic;
    using BankingSystemLibrary.Models;
    using BankingSystemLibrary.Services.AccountFactory;
    using BankingSystemLibrary.Services.BankManager;
    using BankingSystemLibrary.Storages;

    public class Program
    {
        private static readonly string FilePath = @"data.bin";

        public static void Main(string[] args)
        {
            IAccountManager accountManager = new AccountManager();
            IAccountStorage accountStorage = new BinaryAccountStorage(FilePath, accountManager);
            IBankManager bankManager = new BankManager(accountManager, accountStorage);

            try
            {
                Console.WriteLine("AddTest");
                Addtest(bankManager);

                Console.WriteLine("WithdrawMoneyTest");
                WithdrawMoneyTest(bankManager);

                Console.WriteLine("DepositMoneyTest");
                DepositMoneyTest(bankManager);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }

        private static void Addtest(IBankManager bankManager)
        {
            bankManager.OpenAccount("fname1", "lName", 1m);
            bankManager.OpenAccount("fname2", "lName2", 2m);

            ShowAccouts(bankManager.GetAccounts());
        }

        private static void WithdrawMoneyTest(IBankManager bankManager)
        {
            bankManager.WithdrawMoney("2", 4m);
            ShowAccouts(bankManager.GetAccounts());
        }

        private static void DepositMoneyTest(IBankManager bankManager)
        {
            bankManager.DepositMoney("2", 4m);
            ShowAccouts(bankManager.GetAccounts());
        }

        private static void ShowAccouts(IEnumerable<BankAccount> accounts)
        {
            foreach (var accout in accounts)
            {
                Console.WriteLine(string.Format($"First name: {accout.FirstName,-20} Balance: {accout.Balance,-15} Number: {accout.Number}"), accout);
                Console.WriteLine(string.Format($"Last name: {accout.LastName,-21} Status: {accout.Status,-17} Type: {accout.Type}"), accout);
            }

            Console.WriteLine(new string('-', 80));
        }

        private static void ShowAccouts(params BankAccount[] accounts)
        {
            foreach (var accout in accounts)
            {
                Console.WriteLine(string.Format($"First name: {accout.FirstName,-20} Balance: {accout.Balance,-15} Number: {accout.Number}"), accout);
                Console.WriteLine(string.Format($"Last name: {accout.LastName,-21} Status: {accout.Status,-17} Type: {accout.Type}"), accout);
            }

            Console.WriteLine(new string('-', 80));
        }
    }
}
