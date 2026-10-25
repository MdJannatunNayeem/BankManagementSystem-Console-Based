using BankManagementSystem.Interfaces;
using BankManagementSystem.Models;
using BankManagementSystem.Services;

IBankService bankService = new BankService();

/*
string accountNumberA = bankService.CreateAccount(
    "A",
    "A@example.com",
    "01700000000",
    "Dhaka",
    "1234567890",
    new DateTime(2000, 1, 1));

bool deposited = bankService.Deposit(accountNumberA, 1000);
bool withdrawn = bankService.Withdraw(accountNumberA, 300);

decimal? balance = bankService.GetBalance(accountNumberA);

Console.WriteLine($"Deposit successful: {deposited}");
Console.WriteLine($"Withdraw successful: {withdrawn}");
Console.WriteLine($"Balance: {balance}");


string accountNumberB = bankService.CreateAccount(
    "B",
    "B@example.com",
    "01800000000",
    "Dhaka",
    "1234567891",
    new DateTime(2001, 1, 1));

bool transfer = bankService.Transfer(accountNumberA,accountNumberB,200.00m);
Console.WriteLine($"A to B balance transfer successful: {transfer}");
Console.WriteLine($"A new balance  {bankService.GetBalance(accountNumberA)}");
Console.WriteLine($"B new balance  {bankService.GetBalance(accountNumberB)}");

var transactions=bankService.GetTransactionHistory(accountNumberA);

foreach(var transaction in transactions)
{
    Console.WriteLine($"ID = {transaction.Id} " +
        $"Type= {transaction.Type} Sender = {transaction.SenderAccountNumber} Receiver = {transaction.ReceiverAccountNumber}" +
        $" Amount={transaction.Amount} Status = {transaction.Status}");
}

bool transfer2 = bankService.Transfer(accountNumberA, accountNumberB, 1000.00m);
Console.WriteLine($"A to B balance transfer successful: {transfer2}");
Console.WriteLine($"A new balance  {bankService.GetBalance(accountNumberA)}");
Console.WriteLine($"B new balance  {bankService.GetBalance(accountNumberB)}");
*/




bool isRunning = true;

while (isRunning)
{
    Console.WriteLine("\n===== BANK MANAGEMENT SYSTEM =====");
    Console.WriteLine("1. Create Account");
    Console.WriteLine("2. Deposit");
    Console.WriteLine("3. Withdraw");
    Console.WriteLine("4. Transfer");
    Console.WriteLine("5. Check Balance");
    Console.WriteLine("6. Transaction History");
    Console.WriteLine("0. Exit");
    Console.Write("\nEnter your choice: ");

    string? input = Console.ReadLine();

    if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine("Invalid input! Please enter a number.");
        continue;
    }

    switch (choice)
    {
        case 1:
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Enter email: ");
                string email = Console.ReadLine() ?? "";

                Console.Write("Enter phone number: ");
                string phone = Console.ReadLine() ?? "";

                Console.Write("Enter address: ");
                string address = Console.ReadLine() ?? "";

                Console.Write("Enter NID number: ");
                string nid = Console.ReadLine() ?? "";

                Console.Write("Enter date of birth (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime dob))
                {
                    Console.WriteLine("Invalid date of birth!");
                    break;
                }

                string accountNumber = bankService.CreateAccount(
                    name, email, phone, address, nid, dob);

                Console.WriteLine(
                    $"Account created successfully! Account Number: {accountNumber}");
                break;
            }

        case 2:
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine() ?? "";

                Console.Write("Enter deposit amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount!");
                    break;
                }

                bool success = bankService.Deposit(accountNumber, amount);

                Console.WriteLine(success
                    ? "Deposit successful!"
                    : "Deposit failed! Check account number and amount.");
                break;
            }

        case 3:
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine() ?? "";

                Console.Write("Enter withdrawal amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount!");
                    break;
                }

                bool success = bankService.Withdraw(accountNumber, amount);

                Console.WriteLine(success
                    ? "Withdrawal successful!"
                    : "Withdrawal failed! Check balance, account number and amount.");
                break;
            }

        case 4:
            {
                Console.Write("Enter sender account number: ");
                string sender = Console.ReadLine() ?? "";

                Console.Write("Enter receiver account number: ");
                string receiver = Console.ReadLine() ?? "";

                Console.Write("Enter transfer amount: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                {
                    Console.WriteLine("Invalid amount!");
                    break;
                }

                bool success = bankService.Transfer(sender, receiver, amount);

                Console.WriteLine(success
                    ? "Transfer successful!"
                    : "Transfer failed! Check account numbers, amount and balance.");
                break;
            }

        case 5:
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine() ?? "";

                decimal? balance = bankService.GetBalance(accountNumber);

                if (balance.HasValue)
                    Console.WriteLine($"Current balance: {balance.Value:F2}");
                else
                    Console.WriteLine("Account not found.");

                break;
            }

        case 6:
            {
                Console.Write("Enter account number: ");
                string accountNumber = Console.ReadLine() ?? "";

                List<Transaction> transactions =
                    bankService.GetTransactionHistory(accountNumber);

                if (transactions.Count == 0)
                {
                    Console.WriteLine("No transactions found.");
                    break;
                }

                Console.WriteLine("\n===== TRANSACTION HISTORY =====");

                foreach (var transaction in transactions)
                {
                    Console.WriteLine(
                        $"ID: {transaction.Id} | " +
                        $"Type: {transaction.Type} | " +
                        $"Sender: {transaction.SenderAccountNumber} | " +
                        $"Receiver: {transaction.ReceiverAccountNumber} | " +
                        $"Amount: {transaction.Amount:F2} | " +
                        $"Status: {transaction.Status} | " +
                        $"Date: {transaction.DateTime}");
                }

                break;
            }

        case 0:
            isRunning = false;
            Console.WriteLine("Thank you for using Bank Management System!");
            break;

        default:
            Console.WriteLine("Invalid choice! Select an option from 0 to 6.");
            break;
    }
}