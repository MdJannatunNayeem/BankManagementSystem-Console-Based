

using System;

namespace BankManagementSystem.Models
{
    public class Transaction
    {

        public enum TransactionType
        {
            Deposit,
            Withdrawal,
            Transfer
        }

        public enum StatusType
        {
            Sucessful,
            Error,
            Pending
        }

        public string Id { get; private set; }
        public TransactionType Type {  get; set; }
        public decimal Amount {  get; private set; }
        public DateTime DateTime { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public StatusType Status { get; set; }

        

        public Transaction( int id,TransactionType type, decimal amount, string senderAccountNumber, string receiverAccountNumber, StatusType status)
        {
            Id = id.ToString("D6");
            Type = type;
            Amount = amount;
            DateTime = DateTime.UtcNow;
            SenderAccountNumber = senderAccountNumber;
            ReceiverAccountNumber = receiverAccountNumber;
            Status = status;
        }
    }
}
