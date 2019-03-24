using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***********************");
            Console.WriteLine("Welcome to my Bank!");
            Console.WriteLine("***********************");
            while (true)
            {
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Print my accounts");
                Console.Write("Select an option:");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the Bank");
                        return;

                    case "1":
                        Console.Write("Email Addrerss: ");
                        var emailAddress = Console.ReadLine();

                        var accountTypes = Enum.GetNames(typeof(AccountType));
                        for (int i = 0; i < accountTypes.Length; i++)
                        {
                            Console.WriteLine($"{i}. {accountTypes[i]}");
                        }
                        Console.Write("Account Type: ");
                        var accountType = Enum.Parse<AccountType>(Console.ReadLine());

                        Console.Write("Amount to deposit: ");
                        var amount = Convert.ToDecimal(Console.ReadLine());

                        var a1 = Bank.CreateAccount(emailAddress, accountType, amount);
                        Console.WriteLine($"AN: {a1.AccountNumber}, CD: {a1.CreatedDate}, " +
                            $"Balance: {a1.Balance:C}, EA: {a1.EmailAddress}, AT: {a1.AccountType}");

                        break;
                    case "2":

                    case "3":

                    case "4":

                    default:
                        break;
                }
            }

        }
    }
}
