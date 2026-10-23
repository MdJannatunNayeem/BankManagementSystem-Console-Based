using BankManagementSystem.Interfaces;
using BankManagementSystem.Services;

IBankService bankService = new BankService();

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