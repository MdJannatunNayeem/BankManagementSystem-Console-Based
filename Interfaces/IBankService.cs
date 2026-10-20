
using BankManagementSystem.Models;

namespace BankManagementSystem.Interfaces
{
    public interface IBankService
    {
        public string CreateAccount(string name, string email, string phoneNumber, string address, string nIDnumber, DateTime dateOfBirth);
        public bool Deposit(string accountNumber,decimal amount);
        public bool Withdraw(string accountNumber,decimal amount);
        public bool Transfer(string senderAccountNumber,string receiverAccountNumber, decimal amount);
        public decimal? GetBalance(string accountNumber);
        public List<Transaction> GetTransactionHistory(string accountNumber);
    }
}
