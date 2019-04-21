using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BankApp
{
    static class Bank
    {
        private static BankContext db = new BankContext();

        /// <summary>
        /// Creates an account in the bank
        /// </summary>
        /// <param name="emailAddress">Email address of the account</param>
        /// <param name="accountType">Type of the account</param>
        /// <param name="initialDeposit">Initial amount to deposit</param>
        /// <returns></returns>
        public static Account CreateAccount(string emailAddress, AccountType accountType, decimal initialDeposit)
        {
            if(string.IsNullOrEmpty(emailAddress) || string.IsNullOrWhiteSpace(emailAddress))
            {
                throw new ArgumentNullException("emailAddress", "Email address is required!");
            }
           
            var a1 = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if(initialDeposit>0)
            {
                a1.Deposit(initialDeposit);
            }
            db.Accounts.Add(a1);
            db.SaveChanges();

            return a1;
        }

        public static IEnumerable<Account> GetAccountsForUser(string emailAddress)
        {
            return db.Accounts
                .Where(t =>t.EmailAddress == emailAddress);
        }

        public static IEnumerable<Transaction> GetTransactionForAccountnumber(int accountNumber)
        {
            return db.Transactions
                .Where(t => t.AccountNumber == accountNumber)
                .OrderByDescending(t => t.TransactionDate);
        }
        public static Account GetAccountByAccountNumber(int accountNumber)
        {
            var account = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (account == null)
            {
                throw new ArgumentNullException("account number", "Account number is required!");
            }
            return account;
        }
        public static void Deposit(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            account.Deposit(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Credit,
                Description = "Bank Deposit",
                Amount = amount,
                AccountNumber = accountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();

        }

        public static void Withdraw(int accountNumber, decimal amount)
        {
            var account = GetAccountByAccountNumber(accountNumber);
            if(amount > account.Balance)
            {
                throw new ArgumentOutOfRangeException("amount", "Amount exceeds the balance");
            }
            account.Withdraw(amount);

            var transaction = new Transaction
            {
                TransactionDate = DateTime.Now,
                TransactionType = TransactionType.Debit,
                Description = "Bank Withdrawl",
                Amount = amount,
                AccountNumber = accountNumber
            };

            db.Transactions.Add(transaction);
            db.SaveChanges();
        }
    }
}
