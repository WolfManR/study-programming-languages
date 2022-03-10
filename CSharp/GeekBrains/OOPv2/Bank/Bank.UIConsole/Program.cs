using Bank.Core;

using static System.Console;

BankAccount bankAccount = new(5m);
BankAccount bankAccount2 = new(BankAccountType.Deposit);
BankAccount bankAccount3 = new(10.3m, BankAccountType.Credit);

WriteLine(bankAccount);
WriteLine(bankAccount2);
WriteLine(bankAccount3);

bankAccount.Deposit(19.2m);
bankAccount.Deposit(144.67m);
bankAccount.TryWithdraw(120.2m);

WriteLine(bankAccount);

const decimal transferAmount = 40m;
string transferMessage = $"Transfer of sum {transferAmount} from {bankAccount.Id} to {bankAccount2.Id} was";
bool transferResult = bankAccount.TryDepositTo(bankAccount2, transferAmount);

WriteLine($"{transferMessage} {(transferResult ? "succeed" : "failed")}");
WriteLine(bankAccount);
WriteLine(bankAccount2);

WriteLine("\n");

WriteLine($"{bankAccount}\nAnd\n{bankAccount2}\nis {(bankAccount == bankAccount2 ? "equals" : "not equals")}");

WriteLine("\n");

WriteLine($"{bankAccount2}\nAnd\n{bankAccount3}\nis {(bankAccount != bankAccount2 ? "not equals" : "equals")}");

WriteLine("\n");

WriteLine($"{bankAccount}\nAnd\n{bankAccount2}\nis {(bankAccount.GetHashCode() == bankAccount2.GetHashCode() ? "equals" : "not equals")} on hash codes");