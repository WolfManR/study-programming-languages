namespace CustomCollections.Core.Graph;

public class Node
{
    public bool IsVisited { get; set; }
    public int Value { get; set; }
    public List<Edge> Edges { get; }

    public Node(int value, List<Edge> edges = null)
    {
        Value = value;
        Edges = edges ?? new List<Edge>();
    }

    public void AddConnection(Edge edge)
    {
        _ = edge ?? throw new ArgumentNullException(nameof(edge));
        Edges.Add(edge);
    }
}