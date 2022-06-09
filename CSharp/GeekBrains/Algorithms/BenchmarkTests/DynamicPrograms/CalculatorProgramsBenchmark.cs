using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkTests.DynamicPrograms;

[MemoryDiagnoser]
[Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class CalculatorProgramsBenchmark
{
    private static int CalculatorProgramsWithSwitch(int n)
    {
        return n switch
               {
                   1 => 1,
                   > 1 => n % 2 == 0
                       ? CalculatorProgramsWithSwitch(n - 1) +
                         CalculatorProgramsWithSwitch(n / 2)
                       : CalculatorProgramsWithSwitch(n - 1),
                   _ => throw new ArgumentException(null, nameof(n))
               };
    }

    private static int CalculatorProgramsWithIf(int n)
    {
        if (n <= 0) throw new ArgumentException(null, nameof(n));
        if (n == 1) return 1;
        if (n % 2 == 0) return CalculatorProgramsWithIf(n - 1) + CalculatorProgramsWithIf(n / 2);
        return CalculatorProgramsWithIf(n - 1);
    }

    [Benchmark]
    public void CalcPrograms_WithSwitch()
    {
        CalculatorProgramsWithSwitch(110);
    }

    [Benchmark] // winner as must be
    public void CalcPrograms_WithIf()
    {
        CalculatorProgramsWithIf(110);
    }
}