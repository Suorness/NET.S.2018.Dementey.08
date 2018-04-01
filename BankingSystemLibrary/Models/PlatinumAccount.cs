namespace BankingSystemLibrary.Models
{
    public class PlatinumAccount : BankAccount
    {
        protected PlatinumAccount(
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
            return (int)(amount * balance);
        }

        protected override int ReceivingBonusOnWithdrawMoney(decimal amount, decimal balance)
        {
            return (int)(amount * 0.1m * balance);
        }
    }
}
