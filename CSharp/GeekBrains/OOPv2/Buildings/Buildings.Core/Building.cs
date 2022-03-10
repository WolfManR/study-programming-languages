namespace Buildings.Core;

public sealed class Building
{
    private static int _idCounter;
    private static int IdCounter => ++_idCounter;

    private readonly int _id;
    private double _height;
    private int _numberOfStoreys;
    private int _countOfEntrances;
    private int _countOfApartments;

    internal Building() => _id = IdCounter;

    public int Id => _id;

    public double Height { get => _height; set => _height = value; }
    public int NumberOfStoreys { get => _numberOfStoreys; set => _numberOfStoreys = value; }
    public int CountOfEntrances { get => _countOfEntrances; set => _countOfEntrances = value; }
    public int CountOfApartments { get => _countOfApartments; set => _countOfApartments = value; }

    public double CalculateHeightOfStorey() => Height / NumberOfStoreys;
    public double CalculateNumberOfApartmentsInEntrace() => (double)CountOfApartments / CountOfEntrances;
    public double CalculateNumberOfApartmentsOnStorey() => (double)CountOfApartments / NumberOfStoreys;
}