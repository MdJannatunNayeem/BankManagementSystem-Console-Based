# Bank Management System

A console-based Bank Management System built with **C# and .NET** to practice Object-Oriented Programming (OOP), interfaces, collections, LINQ, and exception-safe banking operations.

The application allows users to create bank accounts, deposit and withdraw money, transfer funds between accounts, check balances, and view transaction history through an interactive console menu.

## Features

- **Create Account:** Create a bank account with personal information and a unique account number.
- **Deposit Money:** Deposit money into an existing account.
- **Withdraw Money:** Withdraw money when sufficient balance is available.
- **Transfer Money:** Transfer funds between two accounts.
- **Check Balance:** View the current balance of an account.
- **Transaction History:** View deposit, withdrawal, and transfer records for an account.
- **Input Validation:** Reject invalid menu choices, malformed amounts, invalid dates, and unknown account numbers.
- **Transaction Tracking:** Record successful transactions with IDs, amounts, timestamps, transaction types, and statuses.

## Technologies Used

- C#
- .NET
- Object-Oriented Programming (OOP)
- Interfaces
- Generic Collections (`List<T>`)
- LINQ
- Exception and input handling
- Git and GitHub

## Project Structure

```text
BankManagementSystem/
├── Interfaces/
│   └── IBankService.cs
├── Models/
│   ├── BankAccount.cs
│   └── Transaction.cs
├── Services/
│   └── BankService.cs
├── Program.cs
├── BankManagementSystem.csproj
├── BankManagementSystem.sln
└── README.md
```

*Note: The structure above represents the intended organization. Adjust it if your actual project folders differ.*

## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- Visual Studio, Visual Studio Code, or another C#-compatible editor
- Git (optional)

Check whether .NET is installed:

```bash
dotnet --version
```

### Installation

1. Clone the repository:

   ```bash
   git clone <YOUR_GITHUB_REPOSITORY_URL>
   ```

2. Navigate to the project directory:

   ```bash
   cd BankManagementSystem
   ```

3. Restore dependencies:

   ```bash
   dotnet restore
   ```

4. Run the application:

   ```bash
   dotnet run
   ```

If the `.csproj` file is inside a subdirectory, navigate to that directory before running the application.

## Application Menu

```text
===== BANK MANAGEMENT SYSTEM =====
1. Create Account
2. Deposit
3. Withdraw
4. Transfer
5. Check Balance
6. Transaction History
0. Exit
```

Select an option by entering the corresponding number.

## How It Works

### 1. Account Creation

Users provide their name, email, phone number, address, NID number, and date of birth. The application generates a sequential account number, such as `000001`.

### 2. Deposits and Withdrawals

- Deposits require a valid account and a positive amount.
- Withdrawals require a valid account, a positive amount, and sufficient funds.
- The account balance is updated only when the operation succeeds.

### 3. Money Transfers

The application validates both accounts and checks whether the sender has sufficient funds. It updates both account balances and records the transaction only after a successful transfer.

### 4. Transaction History

Transaction history is filtered by sender or receiver account number and sorted by transaction date, newest first.

## Object-Oriented Design

The project is organized into models, an interface, and a service layer.

- **`BankAccount`:** Stores account information and controls balance changes through deposit and withdrawal methods.
- **`Transaction`:** Represents a transaction with its ID, type, amount, timestamp, sender, receiver, and status.
- **`IBankService`:** Defines the banking operations available to the application.
- **`BankService`:** Implements the banking business logic using collections and LINQ.
- **`Program.cs`:** Provides the interactive console interface.

## Testing

Manual testing has been performed for the core banking operations.

| Test scenario | Expected result |
|---|---|
| Create an account with valid information | Account created |
| Enter an invalid date | Date rejected |
| Deposit a positive amount | Balance increases |
| Deposit zero or a negative amount | Operation rejected |
| Withdraw within available balance | Balance decreases |
| Withdraw more than the balance | Operation rejected |
| Transfer between valid accounts | Both balances update correctly |
| Transfer with insufficient funds | Transfer rejected; balances unchanged |
| Transfer to the same account | Transfer rejected |
| Search using an invalid account number | Account not found |
| View transaction history | Relevant transactions displayed |

**Testing note:** Empty-field validation and stricter date-of-birth validation are planned improvements. Automated unit tests have not yet been added.

## Limitations

- Account and transaction data are stored in memory.
- All data is lost when the application closes or restarts.
- The application does not use a database or persistent storage.
- Authentication, authorization, and secure handling of customer information are not implemented.
- This is an educational project, not a production-ready banking system.

## Future Improvements

- Add automated unit tests using xUnit.
- Improve input validation and error messages.
- Persist account and transaction data using a database such as SQL Server.
- Add account authentication and role-based access.
- Introduce logging and more structured error handling.
- Develop a REST API using ASP.NET Core.

## Learning Objectives

This project was developed to practice:

- C# fundamentals and OOP principles
- Encapsulation and interfaces
- Collections and LINQ queries
- Separation of concerns
- Basic banking business logic
- Input validation and manual testing
- Git and GitHub project management

## License

This project is intended for educational and learning purposes. Add a license file if you plan to distribute it under a specific open-source license.
