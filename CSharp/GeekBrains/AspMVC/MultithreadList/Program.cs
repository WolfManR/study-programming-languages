using MultithreadList;

Random random = new(648);

const int addTimes = 100;
const int removeTimes = 100;

const int printDelay = 1000;
const int addDelay = 100;
const int removeDelay = 100;

MultithreadList<int> wrapper = new();

for (var i = 0; i < 5; i++)
{
    LaunchThread(new DTO(addTimes, addDelay, wrapper), ThreadType.Increment, i);
    LaunchThread(new DTO(removeTimes, removeDelay, wrapper), ThreadType.Decrement, i);
    LaunchThread(new DTO(1, printDelay, wrapper), ThreadType.Print, i);
}

Console.WriteLine("waiting...");
Thread.Sleep(4000);
LaunchThread(new DTO(1, printDelay, wrapper), ThreadType.Print, 1);
Console.WriteLine("Main Thread - Work done");

void LaunchThread(DTO launchDTO, ThreadType threadType, int number)
{
    Thread? thread = threadType switch
    {
        ThreadType.Increment => new Thread(dto =>
        {
            if (dto is DTO d) Increment(d.Times, d.Delay, d.ListWrapper);
        })
        { Name = $"Increment {number}" },
        ThreadType.Decrement => new Thread(dto =>
        {
            if (dto is DTO d) Decrement(d.Times, d.Delay, d.ListWrapper);
        })
        { Name = $"Decrement {number}" },
        ThreadType.Print => new Thread(dto =>
        {
            if (dto is DTO d) Print(d.Times, d.Delay, d.ListWrapper);
        })
        { Name = $"Print {number}" },
        _ => null
    };
    thread?.Start(launchDTO);
}

void Increment(int maxTimes, int delay, MultithreadList<int> wrapper)
{
    for (var i = 0; i < maxTimes; i++)
    {
        wrapper.Add(random.Next(1000));
        Thread.Sleep(delay);
    }
}

static void Decrement(int maxTimes, int delay, MultithreadList<int> wrapper)
{
    for (var i = 0; i < maxTimes; i++)
    {
        wrapper.Remove(wrapper.GetLast());
        Thread.Sleep(delay);
    }
}

static void Print(int maxTimes, int delay, MultithreadList<int> wrapper)
{
    (string threadName, int threadId) = (Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
    for (var i = 0; i < maxTimes; i++)
    {
        Console.WriteLine($"{threadName} Id : {threadId} - List Values: {string.Join(", ", wrapper.GetData())}");
        Thread.Sleep(delay);
    }
}

enum ThreadType { Increment, Decrement, Print }

readonly struct DTO
{
    public DTO(int times, int delay, MultithreadList<int> listWrapper)
    {
        Times = times;
        Delay = delay;
        ListWrapper = listWrapper;
    }

    public int Times { get; }
    public int Delay { get; }
    public MultithreadList<int> ListWrapper { get; }
}