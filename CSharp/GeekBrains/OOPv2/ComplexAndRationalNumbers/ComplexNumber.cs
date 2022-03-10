using System.Globalization;

namespace ComplexAndRationalNumbers;

public class ComplexNumber : IEquatable<ComplexNumber?>
{
    private static readonly double _imaginaryUnit = MathF.Sqrt(-1);

    public ComplexNumber() : this(0, 0) { }

    public ComplexNumber(double realPart, double imaginaryPart)
    {
        RealPart = realPart;
        ImaginaryPart = imaginaryPart;
    }

    public static double EqualityPrecision { get; set; } = 0.0004;

    public double RealPart { get; set; }
    public double ImaginaryPart { get; set; }

    public double ImaginaryUnit => _imaginaryUnit;


    // Описать класс комплексных чисел.
    // Реализовать операцию сложения, умножения, вычитания, проверку на равенство двух комплексных чисел.
    // Переопределить метод ToString() для комплексного числа.
    // Протестировать на простом примере.


    public override string ToString()
    {
        if (RealPart == 0 && ImaginaryPart == 0) return "0";
        if (RealPart == 0) return $"{ImaginaryPart} * i";
        if (ImaginaryPart == 0) return RealPart.ToString(CultureInfo.InvariantCulture);
        return ImaginaryPart < 0 ? $"{RealPart}{ImaginaryPart}i" : $"{RealPart}+{ImaginaryPart}i";
    }

    public override bool Equals(object? obj) => Equals(obj as ComplexNumber);

    public bool Equals(ComplexNumber? other) =>
        other != null &&
        System.Math.Abs(RealPart - other.RealPart) < EqualityPrecision &&
        System.Math.Abs(ImaginaryPart - other.ImaginaryPart) < EqualityPrecision;

    public override int GetHashCode() => HashCode.Combine(RealPart, ImaginaryPart);
    public static bool operator ==(ComplexNumber? left, ComplexNumber? right) => EqualityComparer<ComplexNumber>.Default.Equals(left, right);
    public static bool operator !=(ComplexNumber? left, ComplexNumber? right) => !(left == right);

    public static ComplexNumber operator +(ComplexNumber? left, ComplexNumber? right)
    {
        ThrowIfOperandsHasNullValue(left, right);
        return new ComplexNumber(left!.RealPart + right!.RealPart, left.ImaginaryPart + right.ImaginaryPart);
    }

    public static ComplexNumber operator -(ComplexNumber? left, ComplexNumber? right)
    {
        ThrowIfOperandsHasNullValue(left, right);
        return new ComplexNumber(left!.RealPart - right!.RealPart, left.ImaginaryPart - right.ImaginaryPart);
    }

    public static ComplexNumber operator *(ComplexNumber? left, ComplexNumber? right)//(a + bi)(c + di) =(ac - bd) + (bc + ad)i.
    {
        ThrowIfOperandsHasNullValue(left, right);
        return new ComplexNumber
        (
            left!.RealPart * right!.RealPart - left.ImaginaryPart * right.ImaginaryPart,
            left.ImaginaryPart * right.RealPart + left.RealPart * right.ImaginaryPart
        );
    }

    private static void ThrowIfOperandsHasNullValue(ComplexNumber? left, ComplexNumber? right)
    {
        if (left is not null && right is not null) return;

        throw new InvalidOperationException("One of operands was null")
        {
            Data =
            {
                [nameof(left)] = left,
                [nameof(right)] = right
            }
        };
    }
}