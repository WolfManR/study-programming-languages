namespace StoreCheckTemplatePrinter.DataModels;

record Company
{
    public string Name { get; init; }
    public string ShortName { get; init; }
    public string Site { get; init; }
    public long INN { get; init; }
    public string Address { get; init; }
    public long Phone { get; init; }
    public long FN { get; init; }
    public long RNKKT { get; init; }
    public int ZNKKT { get; init; }
    public int FD { get; init; }
    public int FPD { get; init; }
}