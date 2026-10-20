using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementSystem.Models
{
    public class BankAccount
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address {  get; set; }
        public string NIDnumber { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string AccountNumber { get; private set; }

        public double Balance { get; set; }
        public string OTP { get; set; }

        public BankAccount(string name, string password, string email, string phoneNumber, 
            string address, string nIDnumber, DateTime dateOfBirth,string accountNumber,double balance, string oTP)
        {
            Name = name;
            Password = password;
            Email = email;
            PhoneNumber = phoneNumber;
            Address = address;
            NIDnumber = nIDnumber;
            this.dateOfBirth = dateOfBirth;
            AccountNumber = accountNumber;
            Balance = balance;
            OTP = oTP;
        }
    }
}
