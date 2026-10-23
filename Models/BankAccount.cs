

namespace BankManagementSystem.Models
{
    public class BankAccount
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address {  get; set; }
        public string NidNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }


        public BankAccount(string name, string email, string phoneNumber, string address, string nidNumber, DateTime dateOfBirth,string accountNumber)
        {
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            NidNumber = nidNumber;
            DateOfBirth = dateOfBirth;
            AccountNumber=accountNumber;
            Balance = 0;
        }
       
        public bool Deposit(decimal amount)
        {
            if(amount > 0)
            {
                Balance += amount; 
                return true;
            }
            return false;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0 || amount > Balance)
            {
                return false;
            }
            Balance -= amount;
            return true;
        }

        
    }
}
