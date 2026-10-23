using BankManagementSystem.Interfaces;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static BankManagementSystem.Models.Transaction;

namespace BankManagementSystem.Services
{
    public class BankService : IBankService
    {
        private List<BankAccount> BankAccounts = new List<BankAccount>();
        private List<Transaction> Transactions = new List<Transaction>();

        private int _nextAccountNumber = 0;
        private int _nextTransactionId = 0;


        public string CreateAccount(string name, string email,
            string phoneNumber, string address, string nIDnumber, DateTime dateOfBirth)
        {
            _nextAccountNumber++;
            BankAccount bankAccount = new BankAccount(name,email,phoneNumber,address, nIDnumber, dateOfBirth, _nextAccountNumber.ToString("D6"));
            BankAccounts.Add(bankAccount);

            return bankAccount.AccountNumber;
        }

        public bool Deposit(string accountNumber, decimal amount)
        {
            if (amount > 0)
            {
                var account = BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

                if (account == null)
                {
                    return false;
                }

                bool success = account.Deposit(amount);

                if(!success)
                {
                    return false;
                }
                     
                Transaction transaction = new Transaction(_nextTransactionId, TransactionType.Deposit, amount, string.Empty, accountNumber, StatusType.Sucessful);
                _nextTransactionId++;

                Transactions.Add(transaction);
                
                return true;
            }
            return false;
        }
        public bool Withdraw(string accountNumber, decimal amount)
        {
            var account = BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);

            if (account == null)
            {
                return false;
            }
            bool success = account.Withdraw(amount);

            if (!success)
            {
                return false;
            }

            Transaction transaction = new Transaction(_nextTransactionId, TransactionType.Withdrawal, amount, accountNumber, string.Empty, StatusType.Sucessful);
            _nextTransactionId++;

            Transactions.Add(transaction);

            return true;
        }
        public decimal? GetBalance(string accountNumber)
        {
            var account = BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            if (account == null)
            {
                return null;
            }

            return account.Balance;
        }

        public bool Transfer(string senderAccountNumber, string receiverAccountNumber, decimal amount)
        {
            var account_sender = BankAccounts.FirstOrDefault(x=> x.AccountNumber == senderAccountNumber);
            var account_receiver = BankAccounts.FirstOrDefault(x=> x.AccountNumber == receiverAccountNumber);

            if(account_receiver == null || account_sender==null)
            {
                return false;
            }
            if (account_receiver == account_sender)
            {
                return false;
            }

            bool success_for_sender = account_sender.Withdraw(amount);

            if (!success_for_sender)
            {
                return false;
            }

            bool success_for_receiver = account_receiver.Deposit(amount);

            if (!success_for_receiver)
            {
                account_sender.Deposit(amount);
                return false;
            }

            Transaction transaction = new Transaction(_nextTransactionId, TransactionType.Transfer, amount, senderAccountNumber ,receiverAccountNumber, StatusType.Sucessful);
            _nextTransactionId++;

            Transactions.Add(transaction);

            return true;
        }

        public List<Transaction> GetTransactionHistory(string accountNumber)
        {
            List<Transaction> transactions = Transactions.Where(x => x.SenderAccountNumber == accountNumber 
            || x.ReceiverAccountNumber ==accountNumber).OrderByDescending(x=>x.DateTime).ToList();

            return transactions;
        }
    }
}
