namespace CustomThreadPool;

readonly struct ThreadDTO
{
    public IMyThreadPool ThreadPool { get; init; }
    public int CountOfWorks { get; init; }
}