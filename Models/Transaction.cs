

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
            Sucessfull,
            Error,
            Pending
        }

        public int Id { get; set; }
        public TransactionType Type {  get; set; }
        public decimal Amount {  get; private set; }
        public DateTime DateTime { get; set; }
        public string SenderAccountNumber { get; set; }
        public string ReceiverAccountNumber { get; set; }
        public StatusType Status { get; set; }


    }
}
