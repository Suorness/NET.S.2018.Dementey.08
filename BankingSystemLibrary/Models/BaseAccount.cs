﻿namespace BankingSystemLibrary.Models
{
    public class BaseAccount : BankAccount
    {
        private const int Coeff = 10;

        protected BaseAccount(
            string number,
            string lastName,
            string firstName,
            decimal balance,
            int bonus) : base(
                number,
                lastName,
                firstName,
                balance,
                bonus)
        {
        }

        protected override int ReceivingBonusOnDepositMoney(decimal amount, decimal balance)
        {
            if (amount > 1000)
            {
                return Coeff;
            }
            else
            {
                return 0;
            }
        }

        protected override int ReceivingBonusOnWithdrawMoney(decimal amount, decimal balance)
        {
            if (amount < 1000)
            {
                return Coeff;
            }
            else
            {
                return 0;
            }
        }
    }
}
