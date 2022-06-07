namespace SimpleAlgorithms;

public class BinarySearchTests
{
    private static int BinarySearch(int[] inputArray, int searchValue)
    {
        var min = 0;                                   // O(1) - ignore (one time behavior)                     
        var max = inputArray.Length - 1;               // O(1) - ignore (one time behavior)
        while (min <= max)                             // O(log2(n)) - every iteration cut on half
        {                                              // 
            var mid = (min + max) / 2;                 // O(1) - needed?
            if (searchValue == inputArray[mid])        // 
            {                                          // 
                return mid;                            // O(1) - ignore (one time behavior)
            }                                          // 
            else if (searchValue < inputArray[mid])    // 
            {                                          // 
                max = mid - 1;                         // O(1) - needed?
            }                                          // 
            else                                       // 
            {                                          // 
                min = mid + 1;                         // O(1) - needed?
            }                                          // 
        }                                              // 
        return -1;                                     //  O(1) - ignore (one time behavior)
    }                                                  //  O(log2(n))?

    private readonly int[] _arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };

    [Theory]
    [InlineData(2, 3)]
    [InlineData(4, 5)]
    [InlineData(1, 2)]
    [InlineData(5, 6)]
    [InlineData(7, 8)]
    [InlineData(12, 13)]
    public void SearchSuccessfullyFindIndexOfValue(int expectedIndex, int toSearch)
    {
        var index = BinarySearch(_arr, toSearch);

        Assert.Equal(expectedIndex, index);
    }


    [Theory]
    [InlineData(-1, 0)]
    [InlineData(-1, 14)]
    public void SearchFailFindIndexOfValue(int expectedIndex, int toSearch)
    {
        var index = BinarySearch(_arr, toSearch);

        Assert.Equal(expectedIndex, index);
    }
}