namespace ComplexAndRationalNumbers;

public class RationalNumber : IEquatable<RationalNumber?>
{
    private readonly int _hashCode;

    private int _numerator;
    private int _denominator;

    public RationalNumber(int numerator, int denominator)
    {
        if (denominator == 0) throw new ArgumentException("Знаменатель не может быть равен 0");

        _numerator = numerator;
        _denominator = denominator;

        // How do it correctly????????
        _hashCode = HashCode.Combine(_numerator, _denominator);
    }

    // пределить операторы ==, != (метод Equals()), <, >, <=, >=, +, –, ++, --.
    // Переопределить метод ToString() для вывода дроби.
    // Определить операторы преобразования типов между типом дробь, float, int.
    // Определить операторы *, /, %.

    public int Numerator => _numerator;
    public int Denominator => _denominator;

    public override bool Equals(object? obj) => Equals(obj as RationalNumber);
    public bool Equals(RationalNumber? other)
    {
        if (other is null) return false;
        if (_numerator == other._numerator && _denominator == other._denominator) return true;
        return _numerator * other._denominator == _denominator * other._numerator;
    }
    public override int GetHashCode() => _hashCode;

    public override string ToString() => $"{_numerator}/{_denominator}";

    public static bool operator ==(RationalNumber? left, RationalNumber? right) => EqualityComparer<RationalNumber>.Default.Equals(left, right);
    public static bool operator !=(RationalNumber? left, RationalNumber? right) => !(left == right);

    public static bool operator <(RationalNumber? left, RationalNumber? right)
    {
        if (left == right) return false;
        if (left is null) return true;
        if (right is null) return false;

        if (left.Denominator > 0 && right.Denominator > 0) return left.Numerator * right.Denominator < left.Denominator * right.Numerator;

        var leftNumerator = left.Numerator;
        var leftDenominator = left.Denominator;
        if (left.Denominator < 0)
        {
            leftNumerator *= -1;
            leftDenominator *= -1;
        }
        var rightNumerator = right.Numerator;
        var rightDenominator = right.Denominator;
        if (right.Denominator < 0)
        {
            rightNumerator *= -1;
            rightDenominator *= -1;
        }

        return leftNumerator * rightDenominator < leftDenominator * rightNumerator;
    }

    public static bool operator >(RationalNumber? left, RationalNumber? right) => !(left < right) || left != right;
    public static bool operator >=(RationalNumber? left, RationalNumber? right) => !(left < right) || left == right;
    public static bool operator <=(RationalNumber? left, RationalNumber? right) => left < right || left == right;


    public static RationalNumber operator +(RationalNumber? left, RationalNumber? right)
    {
        if (left is null || right is null) throw new InvalidOperationException("Left or Right rational number was null");
        if (left.Denominator == right.Denominator) return new RationalNumber(left.Numerator + right.Numerator, left.Denominator);

        var numerator = left.Numerator * right.Denominator + right.Numerator * left.Denominator;
        var denominator = left.Denominator * right.Denominator;
        return new RationalNumber(numerator, denominator);
    }
    public static RationalNumber operator -(RationalNumber? left, RationalNumber? right)
    {
        if (left is null || right is null) throw new InvalidOperationException("Left or Right rational number was null");
        if (left.Denominator == right.Denominator) return new RationalNumber(left.Numerator - right.Numerator, left.Denominator);

        var numerator = left.Numerator * right.Denominator - right.Numerator * left.Denominator;
        var denominator = left.Denominator * right.Denominator;
        return new RationalNumber(numerator, denominator);
    }

    public static RationalNumber operator ++(RationalNumber? left)
    {
        if (left is null) throw new ArgumentNullException(nameof(left), "Rational number was null");
        left._numerator++;
        return left;
    }

    public static RationalNumber operator --(RationalNumber? left)
    {
        if (left is null) throw new ArgumentNullException(nameof(left), "Rational number was null");
        left._numerator--;
        return left;
    }

    public static RationalNumber operator *(RationalNumber? left, RationalNumber? right)
    {
        if (left is null || right is null) throw new InvalidOperationException("Left or Right rational number was null");
        return new RationalNumber(left.Numerator * right.Numerator, left.Denominator * right.Denominator);
    }

    public static RationalNumber operator /(RationalNumber? left, RationalNumber? right)
    {
        if (left is null || right is null) throw new InvalidOperationException("Left or Right rational number was null");
        if (right.Numerator == 0) throw new InvalidOperationException("Denominator cannot become Zero");
        return new RationalNumber(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
    }

    public static implicit operator float(RationalNumber? from)
    {
        if (from is null) throw new InvalidOperationException("From is null");
        return (float)from.Numerator / from.Denominator;
    }

    public static implicit operator int(RationalNumber? from)
    {
        if (from is null) throw new InvalidOperationException("From is null");
        return from.Numerator / from.Denominator;
    }
}