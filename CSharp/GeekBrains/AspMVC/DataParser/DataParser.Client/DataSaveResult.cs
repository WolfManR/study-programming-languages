namespace DataParser.Client;

public class DataSaveResult
{
    public DataSaveResult(bool isSuccess = true)
    {
        IsSuccess = isSuccess;
    }

    public bool IsSuccess { get; }
    public List<FailureInfo> Failures { get; set; }
}