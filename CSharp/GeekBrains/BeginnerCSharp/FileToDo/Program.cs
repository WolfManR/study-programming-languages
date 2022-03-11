using System.Text;
using FileToDo;
using static System.Console;

const string tempFile = "tasks.json";
ToDo todo;
StringBuilder buffer = new();

todo = ToDo.Load(tempFile);

var isWorkDone = false;
do
{
    RefreshTasks();

    WriteLine(
        @"Input number if you wanna set task as Done, 
if you wana add new task input it's name and press enter, 
press Esc to exit");

    do
    {
        var inputKey = ReadKey();

        if (inputKey.Key == ConsoleKey.Escape)
        {
            isWorkDone = true;
            break;
        }

        // handle moving horizontally, deleting char's

        if (inputKey.Key == ConsoleKey.Enter)
            break;

        buffer.Append(inputKey.KeyChar);
    } while (true);

    if (buffer.Length <= 0) continue;

    var temp = buffer.ToString();
    if (int.TryParse(temp, out var index))
    {
        try
        {
            todo.SetTaskAsDone(index);
        }
        catch (IndexOutOfRangeException)
        {
            todo.AddTask(temp);
        }
    }
    else todo.AddTask(temp);

    RefreshTasks();
    buffer.Clear();


} while (!isWorkDone);

todo.Save(tempFile);

void RefreshTasks()
{
    Clear();
    PrintTasks(todo.GetTasks());
}

static void PrintTasks(IEnumerable<string> tasks)
{
    foreach (var task in tasks)
        WriteLine(task);
}