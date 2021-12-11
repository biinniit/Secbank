using Secbank.Models;

namespace Secbank.Services
{
    public static class UserAccountService
    {
        static List<UserAccount> UserAccounts;
        static int next = 3;

        static UserAccountService()
        {
            UserAccounts = new List<UserAccount>
            {
                new UserAccount(1, "John", "Doe", 3481929110, 300000.00),
                new UserAccount(2, "Muyiwa", "Joseph", 3001929201, 150000.00)
            };
        }

        public static List<UserAccount> GetAll() => UserAccounts;

        public static void Add(string firstName, string lastName, double balance)
        {
            Random generator = new Random();
            long accountNumber = 3000000000 + generator.Next(0, 1000000000);
            UserAccounts.Add(new UserAccount(next++, firstName, lastName, accountNumber, balance));
        }

        public static void Delete(int id)
        {
            UserAccounts.RemoveAt(id - 1);
        }

        public static void Update(int id, string firstName, string lastName, double balance)
        {
            if(UserAccounts.FindIndex(i => i.Id == id) == -1)
                return;

            UserAccounts[id - 1].FirstName = firstName;
            UserAccounts[id - 1].LastName = lastName;
            UserAccounts[id - 1].Balance = balance;
        }
    }
}
