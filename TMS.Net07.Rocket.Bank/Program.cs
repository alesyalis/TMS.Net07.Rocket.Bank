using System;

namespace TMS.Net07.Rocket.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("Alesya","Lis","Alexeevna", new DateTime(1993,12,19));
            client.PrintClient();

            var account = new Account("name", 1000);
            Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

            account.MakeDeposit(100, DateTime.Now);
            Console.WriteLine(account.Balance);
            account.MakeDeposit(500, DateTime.Now);
            Console.WriteLine(account.Balance);

            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new Account("invalid", -100);
            }
            catch (ArgumentOutOfRangeException exp)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(exp.ToString());
            }
            // Test for a negative balance.
            try
            {
                account.MakeWithdrawal(2000, DateTime.Now);
            }
            catch (InvalidOperationException exp)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(exp.ToString());
            }

        }
    }
}
