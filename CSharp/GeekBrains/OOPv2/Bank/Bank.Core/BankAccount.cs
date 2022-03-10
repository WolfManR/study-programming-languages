namespace Bank.Core
{
    public class BankAccount : IEquatable<BankAccount?>
    {
        private readonly Guid _id;
        private readonly BankAccountType _type;

        private decimal _balance;

        public BankAccount(decimal initialBalance) : this(initialBalance, BankAccountType.Deposit) { }

        public BankAccount(BankAccountType type) : this(0, type) { }

        public BankAccount(decimal initialBalance, BankAccountType type)
        {
            if (initialBalance < 0) throw new ArgumentException("Initial balance cannot be lower that zero");
            _balance = initialBalance;
            _id = Guid.NewGuid();
            _type = type;
        }

        public Guid Id => _id;
        public BankAccountType Type => _type;
        public decimal Balance => _balance;

        public void Deposit(decimal amount)
        {
            _balance += amount;
        }

        public bool TryWithdraw(decimal amount)
        {
            if (_balance - amount < 0) return false;
            _balance -= amount;
            return true;
        }

        public bool TryDepositTo(BankAccount to, decimal amount)
        {
            if (!TryWithdraw(amount)) return false;

            to.Deposit(amount);

            return true;
        }

        public override string ToString() => $"Bank account: {Id} of type {Type} with balance {Balance}";

        public override bool Equals(object? obj) => Equals(obj as BankAccount);

        public bool Equals(BankAccount? other)
        {
            return other != null &&
                   _id.Equals(other._id) &&
                   _type == other._type;
        }

        public override int GetHashCode() => HashCode.Combine(_id, _type);

        public static bool operator ==(BankAccount? left, BankAccount? right) => EqualityComparer<BankAccount>.Default.Equals(left, right);
        public static bool operator !=(BankAccount? left, BankAccount? right) => !(left == right);
    }
}