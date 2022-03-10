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

const decimal transferAmount = 40m;
string transferMessage = $"Transfer of sum {transferAmount} from {bankAccount.Id} to {bankAccount2.Id} was";
bool transferResult = bankAccount.TryDepositTo(bankAccount2, transferAmount);

WriteLine($"{transferMessage} {(transferResult ? "succeed" : "failed")}");
Print(bankAccount);
Print(bankAccount2);

static void Print(BankAccount bankAccount)
{
    WriteLine($"Bank account {bankAccount.Id} of type {bankAccount.Type}");
    WriteLine($"Balance: {bankAccount.Balance}");
}