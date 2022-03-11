using System.Text.Json.Serialization;

namespace FileToDo;

internal class ToDoTask
{
    [JsonConstructor]
    public ToDoTask(string title) => Title = title;
    public string Title { get; }
    public bool IsDone { get; set; }

    internal void Done() => IsDone = true;
    
    public override string ToString() => $"[{(IsDone ? "x" : " ")}] {Title}";
}