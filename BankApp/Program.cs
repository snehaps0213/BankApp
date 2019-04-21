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
                Console.WriteLine("5. Print my transactions");
                Console.Write("Select an option:");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank you for visiting the Bank");
                        return;

                    case "1":
                        try
                        {
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
                        }
                        catch (ArgumentNullException nx)
                        {
                            Console.WriteLine($"Email Address Error - {nx.Message} - Please try again!");
                        }
                        catch (ArgumentException ax)
                        {
                            Console.WriteLine($"Account Type Error - {ax.Message} - Please try again!");
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Amount error - Please provide valid amount. Please try again!");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"Sorry something went wrong - {ex.Message} - Please try again!");
                        }

                        break;
                    case "2":
                        PrintAllAccounts();
                        Console.Write("Account number:");
                        var accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to be deposited:");
                        var depositAmount = Convert.ToInt32(Console.ReadLine());
                        Bank.Deposit(accountNumber, depositAmount);
                        Console.WriteLine("Deposit completed successfully");
                        break;

                    case "3":
                        PrintAllAccounts();
                        Console.Write("Account number:");
                        accountNumber = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Amount to be withdraw:");
                        var withdrawAmount = Convert.ToInt32(Console.ReadLine());
                        Bank.Withdraw(accountNumber, withdrawAmount);
                        Console.WriteLine("Withdrawl completed successfully");
                        break;

                    case "4":
                        PrintAllAccounts();
                        break;

                    case "5":
                        PrintAllTransactions();
                        break;

                    default:
                        break;
                }
            }

        }

        private static void PrintAllTransactions()
        {
            PrintAllAccounts();
            Console.Write("Account number: ");
            var accountNumber =Convert.ToInt32(Console.ReadLine());
            var transactions=Bank.GetTransactionForAccountnumber(accountNumber);
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"ID: {transaction.TransactionID}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}");
            }
        }

        private static void PrintAllAccounts()
        {
            Console.Write("Email address: ");
            var emailAddress = Console.ReadLine();
            var accounts = Bank.GetAccountsForUser(emailAddress);
            foreach (var account in accounts)
            {
                Console.WriteLine($"AN: {account.AccountNumber}, CD: {account.CreatedDate}, " +
                $"Balance: {account.Balance:C}, EA: {account.EmailAddress}, AT: {account.AccountType}");
            }
        }
    }
}
