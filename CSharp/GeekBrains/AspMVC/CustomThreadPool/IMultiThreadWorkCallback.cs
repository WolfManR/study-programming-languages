namespace CustomThreadPool;

public interface IMultiThreadWorkCallback
{
    bool IsTaskHandled { get; }
    bool IsFailed { get; }
    Exception Exception { get; }
}