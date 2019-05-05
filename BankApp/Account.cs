using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{

    public enum AccountType
    {
        Checking,
        Savings,
        CD,
        Loan
    }
    /// <summary>
    /// Account that represents
    /// bank account here you can 
    /// withdraw or deposit money
    /// </summary>
    public class Account
    {


        #region Properties
        /// <summary>
        /// Unique number for account
        /// </summary>
        public int AccountNumber { get; private set; }
        /// <summary>
        /// Email address of the account holder
        /// </summary>
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set; }
        public AccountType AccountType { get; set; }
        public DateTime CreatedDate { get; private set; }
        #endregion

        #region Constructors
        public Account()
        {
            //lastAccountNumber++;
            //AccountNumber = lastAccountNumber;
            CreatedDate = DateTime.Now;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Deposit money into your account
        /// </summary>
        /// <param name="amount">Amount to be deposited</param>
        public void Deposit(decimal amount)
        {
            //Balance = Balance + amount;
            Balance += amount;
        }

        /// <summary>
        /// Withdraw money from your account
        /// </summary>
        /// <param name="amount">Amount to be withdrawn</param>
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
        #endregion

    }
}
