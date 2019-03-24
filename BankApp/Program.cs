using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var a1=Bank.CreateAccount("test1@test.com", "Checking", 0);
            Console.WriteLine($"AN:{a1.AccountNumber}, B:{a1.Balance}, EA:{a1.EmailAddress}, AT:{a1.AccountType}, CD:{a1.CreatedDate}");


            var a2 = Bank.CreateAccount("test2@test.com", "Savings", 100);
            Console.WriteLine($"AN:{a2.AccountNumber}, B:{a2.Balance}, EA:{a2.EmailAddress}, AT:{a2.AccountType}, CD:{a2.CreatedDate}");

        }
    }
}
