namespace BankingSystemLibrary.Models
{
    public class GoldAccount : BankAccount
    {
        protected GoldAccount(
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
            return (int)(amount * 2 * balance);
        }

        protected override int ReceivingBonusOnWithdrawMoney(decimal amount, decimal balance)
        {
            return (int)(amount * 0.3m * balance);
        }
    }
}
