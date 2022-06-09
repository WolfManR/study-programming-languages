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