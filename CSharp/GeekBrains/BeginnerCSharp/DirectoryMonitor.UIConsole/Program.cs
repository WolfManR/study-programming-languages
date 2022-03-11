using DirectoryMonitor.Domain;

using System.Diagnostics;

using static System.Console;

// Path to file where program saved check result
const string checkInfoFilePath = "CheckInfo.json";

Checker checkerService;

// Counter of readed files
int readedCounter = 0;

// formatter of message about readed files
const string readedFormatter = "readed {0}";


InitCheckerService();
if (!HandleUserInputPath(out var path)) return;

var watch = new Stopwatch();
watch.Start();

checkerService.StartCheck(path);

watch.Stop();
WriteLine($"Elapsed time {watch.Elapsed.TotalMilliseconds}");


// Initialize main program module and it's dependencies to check files
void InitCheckerService()
{
    var fileReader = new FileReader();
    var checkSavior = new CheckInfoSavior(checkInfoFilePath);
    checkerService = new(fileReader, checkSavior);
    checkerService.OnFileReaded += () =>
    {
        WriteLine(readedFormatter, ++readedCounter);
    };
    checkerService.WorkExceptionHandler += static exception =>
    {
        WriteLine(exception.Message);
        return true;
    };
}

// Get path to check from user and check that this path exists and it's correct, or return if user wanna exit
static bool HandleUserInputPath(out string path)
{
    path = null;
    string input;
    while (true)
    {
        WriteLine("input path to check, or Q if wanna exit");
        input = ReadLine();
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
        {
            WriteLine("incorrect path");
            continue;
        }

        if (input.ToLower() == "q") return false;

        if (Path.HasExtension(input) && !Directory.Exists(input))
        {
            WriteLine("incorrect path");
            continue;
        }

        break;
    }

    path = input;
    return true;
}