namespace ConsoleBankingSystem
{
    using System;
    using System.Collections.Generic;
    using BankingSystemLibrary.BankManager;
    using Models;
    using Storage;

    public class Program
    {
        private static readonly string FilePath = @"data.bin";

        public static void Main()
        {
            IAccountStorage accountStorage = new BinaryAccountStorage(FilePath);
            IBankManager bankManager = new BankManager(accountStorage);

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
            bankManager.OpenAccount("fname1", "lName", 1m, AccountType.GoldAccount);
            bankManager.OpenAccount("fname2", "lName2", 2m, AccountType.PlatinumAccount);

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
