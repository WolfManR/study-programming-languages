using Bank.Core;

using static System.Console;

BankAccount bankAccount = new(5m);
BankAccount bankAccount2 = new(BankAccountType.Deposit);
BankAccount bankAccount3 = new(10.3m, BankAccountType.Credit);

Print(bankAccount);
Print(bankAccount2);
Print(bankAccount3);

bankAccount.Deposit(19.2m);
bankAccount.Deposit(144.67m);
bankAccount.TryWithdraw(120.2m);

Print(bankAccount);

static void Print(BankAccount bankAccount)
{
    WriteLine($"Bank account {bankAccount.Id} of type {bankAccount.Type}");
    WriteLine($"Balance: {bankAccount.Balance}");
}