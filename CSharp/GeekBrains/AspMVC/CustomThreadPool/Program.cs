﻿using CustomThreadPool;

using (IMyThreadPool threadPool = new MyThreadPool(4, 6))
{
    Thread parallel = new Thread(DoWork) { IsBackground = true, Name = "Background assigner" };
    parallel.Start(new ThreadDTO() { CountOfWorks = 8, ThreadPool = threadPool });

    AssignWorks(threadPool, 5);

    Thread.Sleep(20000);
    Console.WriteLine($"Count of threads in thread pool: {threadPool.Count}");

    Console.WriteLine("Start disposing thread pool");
}

Console.WriteLine("Thread pool must be disposed");

static void DoWork(object? arg)
{
    if (arg is not ThreadDTO dto) return;
    AssignWorks(dto.ThreadPool, dto.CountOfWorks);
}

static void AssignWorks(IMyThreadPool threadPool, int countOfWorks = 8)
{
    for (var i = 0; i < countOfWorks; i++)
    {
        threadPool.QueueTask(() =>
        {
            Thread.Sleep(4000);
            Console.WriteLine($"Hello from thread {Thread.CurrentThread.ManagedThreadId} with name {Thread.CurrentThread.Name}");
        });
    }
}