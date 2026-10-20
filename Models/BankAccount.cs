

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

       
    }
}
