namespace Storage
{
    using Models;

    public class AccountDal
    {
        public string Number { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public decimal Balance { get; set; }

        public int Bonus { get; set; }

        public AccountType Type { get; set; }
    }
}
