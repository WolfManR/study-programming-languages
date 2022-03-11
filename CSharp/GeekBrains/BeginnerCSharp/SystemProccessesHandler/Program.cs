using System.Diagnostics;

using static System.Console;

const char prefix = '-';
const string incorrectArgsMsg = "Incorrect arguments line";
const int processNameColumnSize = 50;
int width = BufferWidth - 1;
string rowSeparator = new('-', width);
const string columnShift = "     |";
int pidsColumnSize = width - (processNameColumnSize + columnShift.Length);

HandleCommandLine(args);

WriteLine("Work Done");


void HandleCommandLine(string[] args)
{
    if (args.Length == 0) return;

    List<(char, string)> pairs = new();
    for (var i = 0; i < args.Length; i++)
    {
        if (args[i].StartsWith(prefix))
            pairs.Add((args[i].TrimStart(prefix)[0], null));
        else
        {
            if (pairs.Count == 0)
            {
                WriteLine(incorrectArgsMsg);
                return;
            }
            var (key, value) = pairs.Last();
            if (value is null)
            {
                pairs[^1] = (key, args[i]);
            }
            else
            {
                WriteLine(incorrectArgsMsg);
                return;
            }
        }
    }


    try
    {
        foreach (var (arg, value) in pairs)
        {
            switch (arg)
            {
                case 'h':
                    PrintHelp();
                    break;
                case 'v' when value is not null && int.TryParse(value, out var pid):
                    PrintProcessByPid(pid);
                    break;
                case 'v' when value is not null:
                    PrintProcessByName(value);
                    break;
                case 'v':
                    PrintProcesses();
                    break;
                case 'k' when value is not null && int.TryParse(value, out var pid):
                    KillProcessByPid(pid);
                    break;
                case 'k' when value is not null:
                    KillProcessByName(value);
                    break;
                default:
                    throw new ArgumentException(
                        $"Argument {arg} has incorrect command or incorrect value {value}");
            }
        }
    }
    catch (Exception e)
    {
        WriteLine(e.Message);
    }
}

static void PrintHelp()
{
    var help = $@"
-h              - help
-v              - print processes
-v [PID]        - print process with PID
-v [Name]       - print process with Name
-k [PID]        - shutdown process";
    WriteLine(help);
}

void PrintProcessByPid(int pid)
{
    var process = Process.GetProcessById(pid);
    PrintHeader();
    PrintRow(NormalizeName(process.ProcessName.AsSpan()), pid.ToString());
}

void PrintProcessByName(string name) => PrintGroupedProcesses(GroupProcesses(Process.GetProcessesByName(name)));
void PrintProcesses() => PrintGroupedProcesses(GroupProcesses(Process.GetProcesses()));

static void KillProcessByPid(int pid)
{
    try
    {
        Process.GetProcessById(pid).Kill(true);
    }
    catch { throw; }
}

static void KillProcessByName(string name)
{
    try
    {
        var processes = Process.GetProcessesByName(name);
        processes[0].Kill(true);
    }
    catch { throw; }
}

void PrintHeader()
{
    // Header
    WriteLine($"{"Name",-processNameColumnSize}{columnShift}PID");
    WriteLine(rowSeparator);
}

void PrintRow(string name, string pids)
{
    // Row
    WriteLine($"{name,-processNameColumnSize}{columnShift}{pids}");
    WriteLine(rowSeparator);
}

static string NormalizeName(ReadOnlySpan<char> name) =>
    (name.Length > processNameColumnSize ? name.Slice(0, processNameColumnSize) : name).ToString();

string NormalizePiDs(IReadOnlyList<int> pids)
{
    var linePids = pids.Count == 1 ? pids[0].ToString() : string.Join(", ", pids);
    if (linePids.Length > pidsColumnSize) linePids = linePids[..pidsColumnSize];
    return linePids;
}

void PrintGroupedProcesses(Dictionary<string, List<int>> processes)
{
    PrintHeader();
    foreach (var (key, pids) in processes)
        PrintRow(NormalizeName(key.AsSpan()), NormalizePiDs(pids));
}

static Dictionary<string, List<int>> GroupProcesses(IReadOnlyList<Process> processes)
{
    Dictionary<string, List<int>> groups = new();
    for (var i = 0; i < processes.Count; i++)
    {
        var current = processes[i];
        var name = current.ProcessName;
        if (groups.ContainsKey(name))
            groups[name].Add(current.Id);
        else groups.Add(name, new(new[] { current.Id }));
    }

    return groups;
}