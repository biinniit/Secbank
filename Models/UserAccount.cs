namespace Secbank.Models
{
    public class UserAccount
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long AccountNumber { get; set; }
        public double Balance { get; set; }

        private UserAccount()
        {
            FirstName = "";
            LastName = "";
        }

        public UserAccount(int id, string firstName, string lastName, long accountNumber, double balance)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            AccountNumber = accountNumber;
            Balance = balance;
        }
    }
}
