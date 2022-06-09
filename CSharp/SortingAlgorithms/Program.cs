// See https://aka.ms/new-console-template for more information
using SortingAlgorithms;

Console.WriteLine("Generic swap test");
GenericSwapTest();

Console.WriteLine("Update insert sort test");
UpdateInsertSortTest();

Console.WriteLine("Insertion sort test");
InsertionSortTest();

Console.WriteLine("Quick sort test");
QuickSortTest();

Console.WriteLine("Heap sort test");
HeapSortTest();

Console.WriteLine("Bucket sort test");
BucketSortTest();

Console.WriteLine("External sort test");
ExternalSortTest();

void GenericSwapTest()
{
     var first = 56;
    var second = 984;

    Console.WriteLine($"{first} {second}");
    first.Swap(ref second);
    Console.WriteLine($"{first} {second}");
}

void UpdateInsertSortTest()
{
    var arr = new int[10];
    arr
        .Fill(40, 800)
        .Print()
        .UpdateInsertSort()
        .Print();
}

void InsertionSortTest()
{
    var arr = new int[10];
    arr
        .Fill(40, 800)
        .Print()
        .InsertionSort()
        .Print();
}

void QuickSortTest()
{
    var arr = new int[10];
    arr
        .Fill(40, 800)
        .Print()
        .QuickSort()
        .Print();
}

void HeapSortTest()
{
    var arr = new int[10];
    arr
        .Fill(40, 800)
        .Print()
        .HeapSort()
        .Print();
}

void BucketSortTest()
{
    var arr = new int[14];
    arr.Fill(2, 30).Print();

    var result = BucketSorter.Sort(arr, 4);
    result.Print();
}

void ExternalSortTest()
{

    var arr = new int[14];
    arr.Fill(2, 30).Print();

    // prepare for External Sort
    const string outputDirectory = "ExternalSortTest";
    var fileToSort = $"{outputDirectory}/toSort.txt";
    if (!Directory.Exists(outputDirectory)) Directory.CreateDirectory(outputDirectory);
    using (var sw = new StreamWriter(File.Create(fileToSort)))
    {
        for (var i = 0; i < arr.Length; i++)
        {
            sw.WriteLine(arr[i]);
        }
    }

    var outputFilePath = Path.Combine(Path.GetDirectoryName(fileToSort), "output.txt");
    try
    {
        ExternalSorter sorter = new(5);  // bucket's size can be throw up to user decision if it need
        sorter.Sort(fileToSort, outputFilePath);
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        return;
    }

    // Print sorted output file to console
    using (var sr = new StreamReader(File.OpenRead(outputFilePath)))
    {
        while (!sr.EndOfStream)
        {
            Console.Write(sr.ReadLine() + " ");
        }
    }
}